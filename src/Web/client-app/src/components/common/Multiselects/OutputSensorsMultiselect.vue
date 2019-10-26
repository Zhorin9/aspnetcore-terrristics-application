<template>
    <multiselect
        v-model="selectedSensors"
        track-by="name"
        label="Name"
        placeholder="Wybierz czujnik"
        selectedLabel="Wybrany"
        deselectLabel="Enter aby usunąć"
        :options="outputSensors"
        :searchable="true"
        :multiple="true"
        :close-on-select="true"
        :clear-on-select="false"
        @input="emit"/>
</template>

<script>
    import {mapGetters} from "vuex";
    import types from "../../../store/types";

    export default {
        computed: {
            ...mapGetters({
                outputSensors: types.getters.DICT_GET_OUTPUT_SENSORS,
            }),
        },
        props: {
            selectedSensors: {
                type: Array,
                default: Array(0)
            },
        },
        methods: {
            emit(){
                this.$emit("selected-outputs", this.value);
            }
        }
    }
</script>

<style scoped>

</style>
