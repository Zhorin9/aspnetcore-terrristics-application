<template>
    <b-modal
            id="terraristics-window-add-sensor-blocks-modal"
            title="Dodaj nowe sensory"
            size="lg"
            button-size="sm"
            ref="terraristicsWindowAddSensorBlocksModal">
        <div v-show="failedOnCreate" class="alert alert-danger text-center modal-alert"
             :style="`padding: 0`">
            <p class="text-danger" :style="`font-size: 16px; margin-bottom:0px;`">Nie udało się
                dodać nowego sensora, spróbuj ponownie :(</p>
        </div>
        <form v-if="!waitingForResponse"
              @submit.prevent="handleOk">
            <div class="form-groups form-label col-6">
                <label>Nazwa bloku</label>
                <input v-model="name"
                       name="user-window-add-modal-name"
                       class="form-control"/>
            </div>
            <div class="form-group form-label col-6">
                <label>Opis</label>
                <textarea v-model="description"
                          placeholder="Opis bloku"
                          class="form-control">
                </textarea>
            </div>
            <div class="form-group form-label col-6">
                <label>Wybierz rodzaj czujnika</label>
                <b-form-radio v-model="selectedType" name="measure-sensor" :value=true>Czujnik pomiarowy</b-form-radio>
                <b-form-radio v-model="selectedType" name="control-sensor" :value=false>Czujnik sterujący</b-form-radio>
            </div>
            <div v-if="selectedType"
                 class="form-group form-label col-6">
                <label>Czujniki wejścia</label>
                <input-sensors-multiselect
                        :multiple="false"
                        :selected-sensors="selectedSensor"
                        @selected-inputs="updateSensor"/>
            </div>
            <div v-else
                 class="form-group form-label col-6">
                <label>Czujniki wyjścia</label>
                <output-sensors-multiselect
                        :multiple="false"
                        :selected-sensors="selectedSensor"
                        @selected-outputs="updateSensor"/>
            </div>
        </form>
        <template v-else>
            <loading-page/>
        </template>

        <template v-slot:modal-footer="{ ok, cancel }">
            <b-button size="sm" variant="success" @click="handleOk">
                Zapisz
            </b-button>
            <b-button size="sm" variant="danger" @click="cancel">
                Anuluj
            </b-button>
        </template>
    </b-modal>
</template>

<script lang="ts">
    import {Component, Emit, Prop, Vue} from "vue-property-decorator";
    import {sensorBlockApiImpl} from "@/api/sensor-block-api";
    import {DictionaryModule} from "@/store/modules/dictionary-module";
    import InputSensorsMultiselect from "@/components/common/Multiselects/InputSensorsMultiselect.vue"
    import OutputSensorsMultiselect from "@/components/common/Multiselects/OutputSensorsMultiselect.vue";
    import LoadingPage from "@/components/common/LoadingPage.vue";

    @Component({
        components: {
            LoadingPage,
            OutputSensorsMultiselect,
            InputSensorsMultiselect
        }
    })
    export default class TerraristicsWindowAddSensorBlockModal extends Vue {
        @Prop([Number, String]) windowId!: number | string;

        failedOnCreate: boolean = false;
        waitingForResponse: boolean = false;

        name: string = "";
        description: string = "";
        selectedSensor: SensorKindData | undefined = undefined;
        private type: boolean = true;
        
        public get selectedType(): boolean {
            return this.type;
        }

        public set selectedType(selected: boolean) {
            this.type = selected;
            this.selectedSensor = undefined;
        }

        created() {
            DictionaryModule.DICT_GET_ALL_SENSOR_KINDS();
        }

        saveNewWindow() {
            let sensorToCreate = {
                Name: this.name,
                Description: this.description,
                WindowId: this.windowId,
                Type: this.selectedSensor
            };
            this.waitingForResponse = true;

            sensorBlockApiImpl.createNewSensorBlock(sensorToCreate)
                .then(response => {
                    let sensorBlockId = response.data;
                    this.resetModalDataAndEmitEvent(sensorBlockId);
                })
                .catch(err => {
                    console.error(err.message);
                })
                .finally(() => {
                    this.waitingForResponse = false;
                    this.failedOnCreate = true;
                })
        };

        updateSensor(sensor: SensorKindData) {
            this.selectedSensor = sensor;
        }

        resetModalDataAndEmitEvent(sensorBlockId: number) {
            // @ts-ignore
            this.$refs.terraristicsWindowAddSensorBlocksModal.hide();
            this.createdNewSensorBlocksEmit(sensorBlockId);
        };

        async handleOk(evt: any) {
            try {
                evt.preventDefault();
                this.saveNewWindow();
            } catch (e) {
                console.error(e);
            }
        };

        @Emit()
        createdNewSensorBlocksEmit(sensorBlockId: number) {
            return sensorBlockId;
        }
    }
</script>

<style scoped>
</style>