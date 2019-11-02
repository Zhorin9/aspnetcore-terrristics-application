<template>
    <multiselect
        v-model="value"
        track-by="name"
        label="name"
        placeholder="Wybierz czujnik"
        selectedLabel="Wybrany"
        deselectLabel="Enter aby usunąć"
        :options="inputSensors"
        :searchable="true"
        :multiple="true"
        :show-labels="false"
        @input="emit">
        <template slot="option" slot-scope="props">
            <div>
                <strong><span>{{ props.option.name }} - </span></strong>
                <span class="option__small">{{ props.option.shortDescription }}</span>
            </div>
        </template>
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
        data() {
            return {
                value: this.selectedSensors.length > 0 ? this.selectedSensors : Array(0)
            }
        },
        props: {
            selectedSensors: {
                type: Array,
                default: () => Array(0)
            },
        },
        methods: {
            emit() {
                this.$emit("selected-inputs", this.value);
            }
        }
    }
</script>
