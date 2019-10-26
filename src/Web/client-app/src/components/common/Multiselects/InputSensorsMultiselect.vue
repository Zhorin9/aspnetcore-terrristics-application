<template>
    <multiselect
        v-model="selectedSensors"
        track-by="name"
        label="name"
        placeholder="Wybierz czujnik"
        selectedLabel="Wybrany"
        deselectLabel="Enter aby usunąć"
        :options="inputSensors"
        :multiple="true"
        :custom-label="singleLabel"
        :show-labels="false"
        @input="emit">

        <template slot="singleLabel" slot-scope="props"><span class="option__title">{{ props.option.name }}</span></template>
<!--        <template slot="option" slot-scope="props">-->
<!--            <div class="option__desc"><span class="option__title">{{ props.option.name }}</span><span class="option__small">{{ props.option.name }}</span></div>-->
<!--        </template>-->

<!--        <template slot="singleLabel" slot-scope="props"><span class="option__desc"><span class="option__title">{{ props.option.name }}</span></span></template>-->
<!--        <template slot="option" slot-scope="props">-->
<!--            <div class="option__desc">-->
<!--                <span class="option__title">{{ props.option.name }}</span>-->
<!--                <span class="option__small">{{ props.option.description }}</span>-->
<!--            </div>-->
<!--        </template>-->
    </multiselect>
</template>

<script>
    import {mapGetters} from "vuex";
    import types from "../../../store/types";

    export default {
        computed: {
            ...mapGetters({
                inputSensors: types.getters.DICT_GET_INPUT_SENSORS,
            }),
        },
        props: {
            selectedSensors: {
                type: Array,
                default: Array(0)
            },
        },
        methods: {
            emit() {
                this.$emit("selected-inputs", this.value);
            },
            customLabel ({ name, description }) {
                return `${name} – ${description}`
            }
        }
    }
</script>


<style src="vue-multiselect/dist/vue-multiselect.min.css"></style>
