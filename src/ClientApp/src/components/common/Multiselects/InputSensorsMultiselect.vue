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

<script lang="ts">
    import {mapGetters} from "vuex";
    import {Component, Prop, Vue} from "vue-property-decorator";

    @Component({
        computed: {
            ...mapGetters({
                inputSensors: 'DICT_GET_INPUT_SENSORS'
            })
        }
    })

    export default class InputSensorsMultiselect extends Vue {
        @Prop({default: []}) selectedSensors!: Array<SensorKindData>;
        value: SensorKindModel[] = this.selectedSensors.length > 0 ? this.selectedSensors : Array(0);

        emit() {
            this.$emit("selected-inputs", this.value);
        }
    }
</script>

<style src="vue-multiselect/dist/vue-multiselect.min.css"/>

