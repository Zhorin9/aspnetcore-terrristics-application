<template>
    <multiselect
        v-model="value"
        track-by="Name"
        label="Name"
        placeholder="Wybierz urządzenie "
        selectedLabel="Wybrany"
        deselectLabel="Enter aby usunąć"
        :options="outputSensors"
        :searchable="true"
        :multiple="true"
        :show-labels="false"
        @input="emit">
        <template slot="option" slot-scope="props">
            <div>
                <strong><span>{{ props.option.Name }} - </span></strong>
                <span class="option__small">{{ props.option.ShortDescription }}</span>
            </div>
        </template>
    </multiselect>
</template>

<script lang="ts">
    import {Component, Prop, Vue} from "vue-property-decorator";
    import {DictionaryModule} from "@/store/modules/dictionary-module";

    @Component
    
    export default class OutputSensorsMultiselect extends Vue {
        @Prop({default: []}) selectedSensors!: Array<SensorKindData>;
        value: SensorKindModel[] = this.selectedSensors.length > 0 ? this.selectedSensors : Array(0);
        
        get outputSensors(){
            return DictionaryModule.OutputSensors;
        }
        
        emit() {
            this.$emit("selected-outputs", this.value);
        }
    }
</script>

<style scoped>
    @import '~vue-multiselect/dist/vue-multiselect.min.css';
</style>
