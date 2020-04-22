<template>
    <div v-if="loadingProcess">
        <template v-if="!operationInProgress">
            <b-button variant="primary" size="sm" @click="refreshState">Odśwież stan</b-button>

            <template v-if="!operationFailed">
                <b-button variant="primary" size="sm" class="float-right" @click="toggleState">
                    {{getTurnOffOnButtonDisplay}}
                </b-button>
                <div class="text-center">
                    <font-awesome-icon :icon="['fa', 'lightbulb']" :class="bulbColor" size="10x"/>
                </div>
            </template>
            <template v-else>
                <h4 class="text-danger mt-3 text-center">Wystąpił problem - nie udało sprawdzić się stanu czujnika</h4>
            </template>

        </template>
        <div v-else class="text-center">
            <loading-page :size="5"/>
        </div>
    </div>
    <div v-else>
        Brak danych
    </div>
</template>

<script lang="ts">
    import {Component, Prop} from "vue-property-decorator";
    import {sensorBlockDataApiImpl} from "@/api/sensor-block-data-api";
    import BackendOperationMixin from "@/mixins/backend-operation-mixin";

    @Component
    export default class OutputDigitalSensorBlock extends BackendOperationMixin {
        @Prop({default: null}) sensorBlockId!: number;

        loadingProcess: boolean = true;
        state: boolean = false;

        get getTurnOffOnButtonDisplay() {
            return this.state ? 'Wyłącz' : 'Włącz';
        }

        get bulbColor() {
            return this.state ? 'bulb-yellow' : '';
        }

        created() {
            this.updateCurrentState();
        }

        toggleState() {
            this.startOperation();
            this.state = !this.state;
            
            let outputDataToUpdate = {
                SensorBlockId: this.sensorBlockId,
                State: this.state 
            };

            sensorBlockDataApiImpl.updateOutputData(outputDataToUpdate)
                .then(() => {
                    this.operationSuccess();
                })
                .catch(err => {
                    this.state = !this.state;
                    this.operationFail();
                    console.error(err);
                });
        }

        refreshState() {
            this.updateCurrentState();
        }

        updateCurrentState() {
            this.startOperation();

            sensorBlockDataApiImpl.getOutputState(this.sensorBlockId)
                .then(response => {
                    this.operationSuccess();
                    this.state = response.data;
                })
                .catch(err => {
                    this.operationFail();
                    console.error(err);
                })
        }
    }
</script>

<style scoped>
    .btn-primary {
        color: #fff;
        background-color: #85b262;
        border-color: #85b262;
    }

    .btn-primary:hover,
    .btn-primary:active,
    .btn-primary:visited {
        background-color: #bad669;
        box-shadow: 0 0 0 0.2rem #adc75a;
        border-color: #adc75a;
    }

    .bulb-yellow {
        color: #e3e35d;
    }
</style>