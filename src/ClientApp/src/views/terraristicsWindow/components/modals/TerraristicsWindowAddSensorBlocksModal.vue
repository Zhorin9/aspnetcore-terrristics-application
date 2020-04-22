<template>
    <b-modal
            id="terraristics-window-add-sensor-blocks-modal"
            title="Dodaj nowe sensory"
            size="md"
            button-size="sm"
            ref="terraristicsWindowAddSensorBlocksModal">
        <div v-show="operationFailed" class="alert alert-danger text-center modal-alert"
             :style="`padding: 0`">
            <p class="text-danger" :style="`font-size: 16px; margin-bottom:0px;`">Nie udało się dodać nowego sensora,
                spróbuj ponownie :(</p>
        </div>
        <validation-observer v-if="!operationInProgress" ref="observer" v-slot="{ invalid }">
            <b-form @submit.prevent="handleOk">

                <b-form-group>
                    <label>Nazwa bloku</label>
                    <validation-provider name="name" rules="required" v-slot="{ errors }">
                        <b-form-input v-model="name" :state="errors.length == 0" class="form-control"/>
                        <b-form-invalid-feedback :state="errors.length == 0">
                            {{ errors[0] }}
                        </b-form-invalid-feedback>
                    </validation-provider>
                </b-form-group>

                <b-form-group>
                    <label>Opis</label>
                    <validation-provider name="description" rules="max:250" v-slot="{ errors }">
                        <b-form-textarea v-model="description"
                                         :state="errors.length == 0"
                                         placeholder="Opis bloku"
                                         class="form-control">
                        </b-form-textarea>
                        <b-form-invalid-feedback :state="errors.length == 0">
                            {{ errors[0] }}
                        </b-form-invalid-feedback>
                    </validation-provider>
                </b-form-group>

                <b-form-group>
                    <label>Wybierz rodzaj czujnika</label>
                    <b-form-radio v-model="selectedType" name="measure-sensor" :value=true>Czujnik pomiarowy
                    </b-form-radio>
                    <b-form-radio v-model="selectedType" name="control-sensor" :value=false>Czujnik sterujący
                    </b-form-radio>
                </b-form-group>

                <b-form-group v-if="selectedType">
                    <label>Czujniki wejścia</label>
                    <input-sensors-multiselect
                            :multiple="false"
                            :selected-sensors="selectedSensorKind"
                            @selected-inputs="updateSensor"/>
                </b-form-group>

                <b-form-group v-else>
                    <label>Czujniki wyjścia</label>
                    <output-sensors-multiselect
                            :multiple="false"
                            :selected-sensors="selectedSensorKind"
                            @selected-outputs="updateSensor"/>
                </b-form-group>

            </b-form>
        </validation-observer>
        <template v-else>
            <loading-page/>
        </template>

        <template v-slot:modal-footer="{ ok, cancel }">
            <b-button size="sm" variant="success" @click="handleOk">
                Zapisz
            </b-button>
            <b-button size="sm" variant="danger" @click="hideAndResetModal">
                Anuluj
            </b-button>
        </template>
    </b-modal>
</template>

<script lang="ts">
    import {Component, Emit, Prop} from "vue-property-decorator";
    import {sensorBlockApiImpl} from "@/api/sensor-block-api";
    import {DictionaryModule} from "@/store/modules/dictionary-module";
    import InputSensorsMultiselect from "@/components/common/Multiselects/InputSensorsMultiselect.vue"
    import OutputSensorsMultiselect from "@/components/common/Multiselects/OutputSensorsMultiselect.vue";
    import BackendOperationMixin from "@/mixins/backend-operation-mixin";

    @Component({
        components: {
            OutputSensorsMultiselect,
            InputSensorsMultiselect
        }
    })
    export default class TerraristicsWindowAddSensorBlockModal extends BackendOperationMixin {
        @Prop([Number, String]) windowId!: number | string;
        name: string = "";
        description: string = "";
        selectedSensorKind: SensorKindModel = <SensorKindModel>{};
        type: boolean = true;

        public get selectedType(): boolean {
            return this.type;
        }

        public set selectedType(selected: boolean) {
            this.type = selected;
            this.selectedSensorKind = <SensorKindModel>{};
        }

        created() {
            DictionaryModule.DICT_GET_ALL_SENSOR_KINDS();
        }

        createSensorBlock() {
            this.startOperation();
            let sensorToCreate = {
                Name: this.name,
                Description: this.description,
                WindowId: this.windowId,
                SensorKind: this.selectedSensorKind
            };

            sensorBlockApiImpl.create(sensorToCreate)
                .then(response => {
                    let sensorBlockId = response.data;
                    this.operationSuccess();
                    this.hideAndResetModal();
                    this.createdNewSensorBlock(sensorBlockId);
                })
                .catch(err => {
                    this.operationFail();
                    console.error(err);
                });
        };

        updateSensor(sensor: SensorKindModel) {
            this.selectedSensorKind = sensor;
        }

        hideAndResetModal() {
            this.resetModalData();
            // @ts-ignore
            this.$refs.terraristicsWindowAddSensorBlocksModal.hide();
        }

        async handleOk(evt: any) {
            try {
                evt.preventDefault();
                this.createSensorBlock();
            } catch (e) {
                console.error(e);
            }
        };

        resetModalData(){
            this.name = '';
            this.description = '';
            this.selectedSensorKind = <SensorKindModel>{};
        }

        @Emit()
        createdNewSensorBlock(sensorBlockId: number) {
            return sensorBlockId;
        }
    }
</script>