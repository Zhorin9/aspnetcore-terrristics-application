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
        :multiple="multiple"
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
        @Prop({default: [] as SensorKindData[]}) selectedSensors!: Array<SensorKindData>;
        @Prop({default: true}) multiple!: Boolean;
        value: SensorKindModel[] = this.selectedSensors.length > 0 ? this.selectedSensors : Array(0);
        
        get outputSensors(){
            return DictionaryModule.outputSensors;
        }
        
        emit() {
            this.$emit("selected-outputs", this.value);
        }
    }
</script>

<style scoped>
    @import '~vue-multiselect/dist/vue-multiselect.min.css';
</style>
