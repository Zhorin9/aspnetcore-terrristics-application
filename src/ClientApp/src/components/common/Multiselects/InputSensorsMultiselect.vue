<template>
    <multiselect
            v-model="value"
            track-by="Name"
            label="Name"
            placeholder="Wybierz czujnik"
            selectedLabel="Wybrany"
            deselectLabel="Enter aby usunąć"
            :options="inputSensors"
            :searchable="true"
            :multiple="multiple"
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
    import {Component, Prop, Vue} from "vue-property-decorator";
    import {DictionaryModule} from "@/store/modules/dictionary-module";
    import 'vue-multiselect/dist/vue-multiselect.min.css'

    @Component

    export default class InputSensorsMultiselect extends Vue {       
        @Prop({default: () => [] as SensorKindData[]}) selectedSensors!: Array<SensorKindData>;
        @Prop({default: true}) multiple!: Boolean;
        value: SensorKindModel[] = this.selectedSensors.length > 0 ? this.selectedSensors : Array(0);

        get inputSensors() {
            return DictionaryModule.inputSensors;
        }

        emit() {
            this.$emit("selected-inputs", this.value);
        }
    }
</script>

<style scoped>
    @import '~vue-multiselect/dist/vue-multiselect.min.css';
</style>

