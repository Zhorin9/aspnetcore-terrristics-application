<template>
    <b-modal
        id="add-window-modal"
        title="Dodanie nowego okna"
        size="xl"
        button-size="sm"
        ref="addWindowModal">
        <div v-show="failedOnCreate" class="alert alert-danger text-center modal-alert" :style="`padding: 0`">
            <p class="text-danger" :style="`font-size: 11px; margin-bottom:0px;`">Nie udało się zapisać okna, spróbuj ponownie :(</p>
        </div>
        <form v-if="!waitingForResponse"
              @submit.prevent="handleOk">
            <div class="form-groups form-label col-6">
                <label>Nazwa okna</label>
                <input
                    v-model="name"
                    v-validate="'required|min:3|max:30'"
                    data-vv-as="Nazwa okna"
                    name="user-window-add-modal-name"
                    class="form-control"
                    :class="{ 'is-invalid': errors.collect('user-window-add-modal-name').length > 0 }"/>
                <validation-messages
                    :errors-list="errors.collect('user-window-add-modal-name')"/>
            </div>
            <div class="form-group form-label col-6">
                <label>Opis</label>
                <textarea v-model="description"
                          v-validate="'max:200'"
                          data-vv-as="Opis"
                          name="user-window-add-modal-description"
                          placeholder="Dodatkowy opis"
                          class="form-control"></textarea>
                <validation-messages
                    :errors-list="errors.collect('user-window-add-modal-description')"/>
            </div>
            <div class="row col-12">
                <div class="form-group form-label col-6">
                    <label>Czujniki pomiarowe</label>
                    <input-sensors-multiselect @selected-inputs="updateInputSensors"/>
                </div>
                <div class="form-group form-label col-6">
                    <label>Elementy sterujące</label>
                    <output-sensors-multiselect @selected-outputs="updateOutputSensors"/>
                </div>
                <div class="col-6">
                    <label>Wybrano czujniki pomiarowe:</label>
                    <user-window-modal-table :sensors="inputSensors"
                                             @update-count="updateInputSensorCount"/>
                </div>
                <div class="col-6">
                    <label>Wybrano elementy sterujące:</label>
                    <user-window-modal-table :sensors="outputSensors"
                                             @update-count="updateOutputSensorCount"/>
                </div>
            </div>
        </form>
        <template v-else>
            <loading-page/>
        </template>

        <template v-slot:modal-footer="{ ok, cancel }">
            <b-button size="sm" variant="success" @click="handleOk">
                Zapisz
            </b-button>
            <b-button size="sm" variant="danger" @click="hideAndResetModalData">
                Anuluj
            </b-button>
        </template>
    </b-modal>
</template>

<script>
    import InputSensorsMultiselect from "../../common/Multiselects/InputSensorsMultiselect";
    import OutputSensorsMultiselect from "../../common/Multiselects/OutputSensorsMultiselect";
    import UserWindowModalTable from "./UserWindowModalTable";
    import LoadingPage from "../../common/LoadingPage";

    import {GetWindowFormData} from "../../../utils/object-generator";
    import {windowModalHelper} from "../../../utils/window-modal-helper";
    import {userWindowService} from "../../../services/user-window-service";

    export default {
        components: {
            LoadingPage,
            UserWindowModalTable,
            OutputSensorsMultiselect,
            InputSensorsMultiselect,
        },
        data() {
            return GetWindowFormData();
        },
        methods: {
            async handleOk(evt) {
                evt.preventDefault();
                const result = await this.isValid();

                if (!result) {
                    return;
                }
                this.saveNewWindow();
            },
            hideAndResetModalData() {
                Object.assign(this.$data, GetWindowFormData());
                this.$refs.addWindowModal.hide();
            },
            updateInputSensors(value) {
                this.inputSensors = windowModalHelper.updateSensorsList(this.inputSensors, value);
            },
            updateOutputSensors(value) {
                this.outputSensors = windowModalHelper.updateSensorsList(this.outputSensors, value);
            },
            updateInputSensorCount(value) {
                let inputToUpdate = _.find(this.inputSensors, {'id': value.id});
                inputToUpdate.count = value.count;
            },
            updateOutputSensorCount(value) {
                let outputToUpdate = _.find(this.outputSensors, {'id': value.id});
                outputToUpdate.count = value.count;
            },
            saveNewWindow() {
                let userWindowToCreate = {
                    name: this.name,
                    description: this.description,
                    inputSensors: this.inputSensors,
                    outputSensors: this.outputSensors
                };

                this.waitingForResponse = true;
                userWindowService.addNewWindow(userWindowToCreate)
                    .then(result => {
                        this.hideAndResetModalData();
                    })
                    .catch(err => {
                        console.error();
                    })
                    .finally(() => {
                        this.waitingForResponse = false;
                    })
            },
            async isValid() {
                return await this.$validator.validateAll();
            }
        }
    }
</script>
