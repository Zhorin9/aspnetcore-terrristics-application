<template>
    <b-col cols="6" class="p-5 mt-3">
        <b-card class="card-green">
            <b-card-sub-title class="mb-2">{{sensorBlock.Description}}</b-card-sub-title>
            
                <input-sensor-block v-if="sensorBlock.SensorKind.OutputType === 0 && !operationInProgress"
                                    :sensor-block-id="sensorBlock.Id"
                                    class="text-center"
                                    ref="inputSensorBlock"/>
                <output-analog-sensor-block v-else-if="sensorBlock.SensorKind.OutputType === outputTypesEnum.Analog"
                                            :sensor-block-id="sensorBlock.Id"/>
                <output-digital-sensor-block v-else-if="sensorBlock.SensorKind.OutputType === outputTypesEnum.Digital"
                                             :sensor-block-id="sensorBlock.Id"/>

                <template v-slot:header>
                    <h4 class="mb-0 text-center">#{{sensorBlock.Id}} - {{sensorBlock.Name}}</h4>
                    <template v-if="sensorBlock.SensorKind.Type === inputType">
                        <font-awesome-icon :icon="['fa', 'sync']" class="fa-pull-right cursor-pointer"
                                           v-b-tooltip.hover title="Odśwież wykres"
                                           @click="refreshData"/>
                        <font-awesome-icon :icon="['fa', 'trash']" class="fa-pull-right cursor-pointer"
                                           v-b-tooltip.hover title="Usuń wszystkie dane"
                                           @click="showRemoveAllInputDataModal"/>
                    </template>
                </template>

            <template v-slot:footer>
                <small class="text-muted">{{sensorBlock.SensorKind.Name}} -
                    {{sensorBlock.SensorKind.ShortDescription}}</small>
            </template>

        </b-card>
        <simple-dialog :id="removeAllInputDataModalId"
                       :title="'Czy na pewno chcesz usunąć dane?'"
                       :description="'Po usunięciu danych nie będzie można ich odzyskać.'"
                       @modal-result="removeAllInputData"/>
    </b-col>
</template>

<script lang="ts">
    import {Component, Emit, Prop, Vue} from "vue-property-decorator";
    import PlusComponent from "@/components/common/PlusComponent.vue";
    import InputSensorBlock from "@/components/sensorBlockTypes/InputSensorBlock.vue";
    import OutputAnalogSensorBlock from "@/components/sensorBlockTypes/OutputAnalogSensorBlock.vue";
    import OutputDigitalSensorBlock from "@/components/sensorBlockTypes/OutputDigitalSensorBlock.vue";
    import {sensorTypes, outputTypes} from "@/utils/enums";
    import {SensorBlockModule} from "@/store/modules/sensor-block-module";
    import BackendOperationMixin from "@/mixins/backend-operation-mixin";

    @Component({
        components: {
            OutputDigitalSensorBlock,
            OutputAnalogSensorBlock,
            InputSensorBlock,
            PlusComponent
        }
    })

    export default class SensorBlock extends BackendOperationMixin {
        @Prop({default: {}}) sensorBlock: SensorBlockModel | undefined;

        get outputTypesEnum() {
            return outputTypes;
        }

        get inputType() {
            return sensorTypes.Input;
        }

        get removeAllInputDataModalId() {
            //@ts-ignore
            return 'sensor-block-remove-input-data-modal-' + this.sensorBlock.Id;
        }

        refreshData() {
            //@ts-ignore
            this.$refs.inputSensorBlock.getData();
        }

        showRemoveAllInputDataModal() {
            this.$bvModal.show(this.removeAllInputDataModalId);
        }

        removeAllInputData(value: boolean) {
            if (value) {
                this.startOperation();
                //@ts-ignore
                SensorBlockModule.REMOVE_ALL_INPUT_DATA(this.sensorBlock.Id)
                    .then(() => {
                        this.operationSuccess();
                    })
                    .catch(() => {
                        this.operationFail();
                    })
            }
        }
    }
</script>