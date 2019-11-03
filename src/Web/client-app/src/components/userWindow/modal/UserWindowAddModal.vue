<template>
    <b-modal
        id="add-window-modal"
        title="Dodanie nowego okna"
        size="xl"
        button-size="sm">
        <form @submit.prevent="">
            <div class="form-groups form-label col-6">
                <label>Nazwa okna</label>
                <input
                    v-model="name"
                    v-validate="'required|min:3|max:30'"
                    data-vv-as="Nazwa okna"
                    name="user-window-add-modal-name"
                    class="form-control"
                    :class="{ 'is-invalid': errors.collect('user-window-add-modal-name').length > 0 }"/>
                <validation-messages :errors-list="errors.collect('user-window-add-modal-name')"/>
            </div>
            <div class="form-group form-label col-6">
                <label>Opis</label>
                <textarea v-model="description"
                          v-validate="'max:200'"
                          data-vv-as="Opis"
                          name="user-window-add-modal-description"
                          placeholder="Dodatkowy opis"
                          class="form-control"></textarea>
                <validation-messages :errors-list="errors.collect('user-window-add-modal-description')"/>
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

        <template v-slot:modal-footer="{ ok, cancel }">
            <b-button size="sm" variant="success" @click="ok">
                Zapisz
            </b-button>
            <b-button size="sm" variant="danger" @click="cancel">
                Anuluj
            </b-button>
        </template>
    </b-modal>
</template>

<script>
    import {GetWindowFormData} from "../../../utils/object-generator";
    import InputSensorsMultiselect from "../../common/Multiselects/InputSensorsMultiselect";
    import OutputSensorsMultiselect from "../../common/Multiselects/OutputSensorsMultiselect";
    import UserWindowModalTable from "./UserWindoModalTable";
    import {windowModalHelper} from "../../../utils/window-modal-helper";
    import types from "../../../store/types";

    export default {
        components: {
            UserWindowModalTable,
            OutputSensorsMultiselect,
            InputSensorsMultiselect
        },
        data() {
            return GetWindowFormData();
        },
        methods: {
            ok() {
                // this.$store.dispatch(types.actions.)
                this.resetData();
            },
            cancel() {
                this.resetData();
            },
            resetData() {
                Object.assign(this.$data, GetWindowFormData());
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

        }
    }
</script>

<style src="vue-multiselect/dist/vue-multiselect.min.css"></style>
