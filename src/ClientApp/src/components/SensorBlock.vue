<template>
    <b-col cols="6" class="p-5 mt-3">
        <b-card class="card-green">
            <b-card-sub-title class="mb-2">{{sensorBlock.Description}}</b-card-sub-title>
            <b-card-body>
                <b-card-text>
                </b-card-text>
            </b-card-body>
            <input-sensor-block
                    v-if="sensorBlock.SensorKind.OutputType === 0" :sensor-block-id="sensorBlock.Id"/>
            <output-analog-sensor-block
                    v-else-if="sensorBlock.SensorKind.OutputType === outputTypes.Analog"/>
            <output-digital-sensor-block
                    v-else-if="sensorBlock.SensorKind.OutputType === outputTypes.Digital"/>
            <template v-slot:header>
                <h4 class="mb-0 text-center">{{sensorBlock.Name}}</h4>
            </template>

            <template v-slot:footer>
                <small class="text-muted">{{sensorBlock.SensorKind.Name}} -
                    {{sensorBlock.SensorKind.ShortDescription}}</small>
            </template>
        </b-card>
    </b-col>
</template>

<script lang="ts">
    import {outputTypes} from "@/enums/output-type";
    import {Component, Prop, Vue} from "vue-property-decorator";
    import PlusComponent from "@/components/common/PlusComponent.vue";
    import InputSensorBlock from "@/components/sensorBlockTypes/InputSensorBlock.vue";
    import OutputAnalogSensorBlock from "@/components/sensorBlockTypes/OutputAnalogSensorBlock.vue";
    import OutputDigitalSensorBlock from "@/components/sensorBlockTypes/OutputDigitalSensorBlock.vue";

    @Component({
        components: {OutputDigitalSensorBlock, OutputAnalogSensorBlock, InputSensorBlock, PlusComponent}
    })

    export default class SensorBlock extends Vue {
        @Prop({default: {}}) sensorBlock: SensorBlockModel | undefined;
    }
</script>

<style scoped>
</style>