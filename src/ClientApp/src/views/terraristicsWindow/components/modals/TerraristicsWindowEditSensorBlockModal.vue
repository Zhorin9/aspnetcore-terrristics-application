<template>
    <b-modal
            id="terraristics-window-edit-sensor-blocks-modal"
            title="Aktualizuj podstawowe dane"
            size="md"
            button-size="sm"
            ref="terraristicsWindowEditSensorBlocksModal">
        <div v-show="operationFailed" class="alert alert-danger text-center modal-alert"
             :style="`padding: 0`">
            <p class="text-danger" :style="`font-size: 16px; margin-bottom:0px;`">Edycja się nie udała, spróbuj ponownie
                :(</p>
        </div>
        <validation-observer v-if="!operationInProgress" ref="observer" v-slot="{ invalid }">
            <b-form @submit.prevent="handleOk">
                <div>
                    
                    <span><font-awesome-icon :icon="['fa', 'info']"/> W przypadku zmiany typu czujnika należy usunąć sensor i założyć nowy.</span>
                </div>
                <b-form-group>
                    <label>Nazwa bloku</label>
                    <validation-provider name="name" rules="required" v-slot="{ errors }">
                        <b-form-input v-model="selectedSensorBlock.Name" :state="errors.length == 0" class="form-control"/>
                        <b-form-invalid-feedback :state="errors.length == 0">
                            {{ errors[0] }}
                        </b-form-invalid-feedback>
                    </validation-provider>
                </b-form-group>

                <b-form-group>
                    <label>Opis</label>
                    <validation-provider name="description" rules="max:250" v-slot="{ errors }">
                        <b-form-textarea v-model="selectedSensorBlock.Description"
                                         :state="errors.length == 0"
                                         placeholder="Opis bloku"
                                         class="form-control">
                        </b-form-textarea>
                        <b-form-invalid-feedback :state="errors.length == 0">
                            {{ errors[0] }}
                        </b-form-invalid-feedback>
                    </validation-provider>
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
    export default class TerraristicsWindowEditSensorBlockModal extends BackendOperationMixin {
        @Prop() selectedSensorBlock!: SensorBlockModel;

        created() {
            DictionaryModule.DICT_GET_ALL_SENSOR_KINDS();
        }

        updateSensorBlock() {
            this.startOperation();
            sensorBlockApiImpl.update(this.selectedSensorBlock)
                .then(response => {
                    let sensorBlockId = response.data;
                    this.operationSuccess();
                    this.hideAndResetModal();
                    this.updatedSensorBlock(sensorBlockId);
                })
                .catch(err => {
                    this.operationFail();
                    console.error(err);
                });
        };

        hideAndResetModal() {
            // @ts-ignore
            this.$refs.terraristicsWindowEditSensorBlocksModal.hide();
        }

        async handleOk(evt: any) {
            try {
                evt.preventDefault();
                this.updateSensorBlock();
            } catch (e) {
                console.error(e);
            }
        };

        @Emit()
        updatedSensorBlock(sensorBlockId: number) {
            return sensorBlockId;
        }
    }
</script>