<template>
    <b-modal
        id="add-terraristics-window-modal"
        title="Dodanie nowego okna"
        size="lg"
        button-size="sm"
        ref="addTerraristicsWindowModal">
        <div v-show="failedOnCreate" class="alert alert-danger text-center modal-alert"
             :style="`padding: 0`">
            <p class="text-danger" :style="`font-size: 16px; margin-bottom:0px;`">Nie udało się
                zapisać okna, spróbuj ponownie :(</p>
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
                          class="form-control">
                </textarea>
                <validation-messages
                    :errors-list="errors.collect('user-window-add-modal-description')"/>
            </div>
        </form>
        <template v-else>
            <loading-page/>
        </template>

        <template v-slot:modal-footer="{ ok, cancel }">
            <b-button size="sm" variant="success" @click="handleOk">
                Zapisz
            </b-button>
            <b-button size="sm" variant="danger" @click="resetModalDataAndGoToCreatedWindow">
                Anuluj
            </b-button>
        </template>
    </b-modal>
</template>

<script>
    import LoadingPage from "../../common/LoadingPage";
    import TerraristicsWindowModalTable from "./TerraristicsWindowModalTable";

    import {GetTerraristicsWindowFormData} from "../../../utils/object-generator";
    import {terraristicsWindowService} from "../../../services/terraristics-window-service";

    export default {
        components: {
            LoadingPage,
            TerraristicsWindowModalTable
        },
        data() {
            return GetTerraristicsWindowFormData();
        },
        methods: {
            async handleOk(evt) {
                try {
                    evt.preventDefault();
                    const result = await this.isValid();

                    if (!result) {
                        return;
                    }
                    this.saveNewWindow();
                } catch (e) {

                }
            },
            resetModalDataAndGoToCreatedWindow(id) {
                Object.assign(this.$data, GetTerraristicsWindowFormData());
                this.$refs.addTerraristicsWindowModal.hide();
                this.$route.push({
                    name: 'TerraristicsWindowData',
                    id: id
                });
            },
            saveNewWindow() {
                terraristicsWindowService.addNewWindow(this.name, this.description)
                    .then(result => {
                        this.resetModalDataAndGoToCreatedWindow(result.data);
                    })
                    .catch(err => {
                        console.error(err.message);
                    })
                    .finally(() => {
                        this.waitingForResponse = false;
                        this.failedOnCreate = true;
                    })
            },
            async isValid() {
                return await this.$validator.validateAll();
            }
        }
    }
</script>
