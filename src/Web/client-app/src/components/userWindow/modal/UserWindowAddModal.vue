<template>
    <b-modal
        id="add-window-modal"
        title="Dodanie nowego okna"
        size="xl"
        button-size="sm">

        <form @submit.prevent="">
            <div class="row">
                <div class="form-groups form-label col-6">
                    <label>Nazwa okna</label>
                    <input
                        v-model="name"
                        v-validate="'required'"
                        data-vv-as="Nazwa okna"
                        name="new.window.name.modal"
                        class="form-control"
                        :class="{ 'is-invalid': errors.collect('new.window.name.modal').length > 0 }"/>
                    <validation-messages :errors-list="errors.collect('new.window.name.modal')"/>
                </div>
                <div class="form-group form-label col-6">
                    <label>Opis</label>
                    <textarea v-model="description" placeholder="Dodatkowy opis"
                              class="form-control"></textarea>
                </div>
                <div class="form-group form-label col-6">
                    <label>Typy czujników pomiarowych</label>
                    <input-sensors-multiselect :selected-sensors="inputSensors"
                                               @selected-inputs="updateInputSensors"></input-sensors-multiselect>
                </div>
                <div class="form-group form-label col-6">
                    <label>Typy elementów sterujących</label>
                    <output-sensors-multiselect :selected-sensors="outputSensors"
                                                @selected-outputs="updateOutputSensors"></output-sensors-multiselect>
                </div>
                <div class="col-6">
                    <label>Wybrano czujniki pomiarowe:</label>
                    <table class="table">
                        <thead>
                        <tr>
                            <th>Czujnik</th>
                            <th>Ilość</th>
                            <th>Akcja</th>
                        </tr>
                        </thead>
                        <tbody>
                        <tr v-for="(inputSensor, index) in groupedInputSensors">
                            <td :key="`input-sensor-{{index}}`">
                                {{inputSensor.name}}
                            </td>
                            <td>
                                {{inputSensor.count}}
                            </td>
                            <td>
                                <button @click="increaseCount(inputSensor)">Dodaj</button>
                                <button>Usuń</button>
                            </td>
                        </tr>
                        </tbody>
                    </table>
                    <ul>
                        <li v-for="(inputSensor,index) in groupedInputSensors"
                            :key="`input-sensor-{{index}}`">{{inputSensor.name}}
                        </li>
                    </ul>
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
    import {mapGetters} from "vuex";
    import InputSensorsMultiselect from "../../common/Multiselects/InputSensorsMultiselect";
    import OutputSensorsMultiselect from "../../common/Multiselects/OutputSensorsMultiselect";
    import {windowModalHelper} from "../../../utils/window-modal-helper";

    export default {
        components: {
            OutputSensorsMultiselect,
            InputSensorsMultiselect
        },
        computed: {
            groupedInputSensors() {
                return windowModalHelper.groupSensors(this.inputSensors);
            }
        },
        data() {
            return GetWindowFormData();
        },
        methods: {
            ok() {
                this.resetData();
            },
            cancel() {
                this.resetData();
            },
            resetData() {
                Object.assign(this.$data, GetWindowFormData());
            },
            updateInputSensors(value) {
                this.inputSensors = value;
            },
            updateOutputSensors(value) {
                this.outputSensors = value;
            },
            increaseCount(value){
                console.log(value);
            }
        }
    }
</script>

<style src="vue-multiselect/dist/vue-multiselect.min.css"></style>
