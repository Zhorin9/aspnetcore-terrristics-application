<template>
    <b-col cols="6" class="p-5 mt-3">
        <b-card class="card-green">
            <b-card-sub-title class="mb-2">{{sensorBlock.Description}}</b-card-sub-title>

            <input-sensor-block v-if="sensorBlock.SensorKind.OutputType === 0"
                                :sensor-block-id="sensorBlock.Id"
                                class="text-center"
                                ref="inputSensorBlock"/>
            <output-analog-sensor-block v-else-if="sensorBlock.SensorKind.OutputType === outputTypesEnum.Analog" :sensor-block-id="sensorBlock.Id"/>
            <output-digital-sensor-block v-else-if="sensorBlock.SensorKind.OutputType === outputTypesEnum.Digital" :sensor-block-id="sensorBlock.Id"/>

            <template v-slot:header>
                <h4 class="mb-0 text-center">#{{sensorBlock.Id}} - {{sensorBlock.Name}}</h4>
                <font-awesome-icon v-if="sensorBlock.SensorKind.OutputType === 0" :icon="['fa', 'sync']" class="fa-pull-right cursor-pointer" @click="refreshData"/>
            </template>
            <template v-slot:footer>
                <small class="text-muted">{{sensorBlock.SensorKind.Name}} -
                    {{sensorBlock.SensorKind.ShortDescription}}</small>
            </template>
        </b-card>
    </b-col>
</template>

<script lang="ts">
    import {Component, Prop, Vue} from "vue-property-decorator";
    import PlusComponent from "@/components/common/PlusComponent.vue";
    import InputSensorBlock from "@/components/sensorBlockTypes/InputSensorBlock.vue";
    import OutputAnalogSensorBlock from "@/components/sensorBlockTypes/OutputAnalogSensorBlock.vue";
    import OutputDigitalSensorBlock from "@/components/sensorBlockTypes/OutputDigitalSensorBlock.vue";
    import {outputTypes} from "@/utils/enums";

    @Component({
        components: {
            OutputDigitalSensorBlock,
            OutputAnalogSensorBlock,
            InputSensorBlock,
            PlusComponent
        }
    })

    export default class SensorBlock extends Vue {
        @Prop({default: {}}) sensorBlock: SensorBlockModel | undefined;

        get outputTypesEnum(){
            return outputTypes;
        }
        
        refreshData() {
            //@ts-ignore
            this.$refs.inputSensorBlock.getData();
        }
    }
</script>

<style scoped>
</style>