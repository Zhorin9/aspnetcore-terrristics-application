<template>
    <b-modal
            id="user-window-add-modal"
            title="Dodanie nowego okna"
            size="lg"
            button-size="sm"
            ref="addUserTerraristicWindowModal">
        <div v-show="failedOnCreate" class="alert alert-danger text-center modal-alert"
             :style="`padding: 0`">
            <p class="text-danger" :style="`font-size: 16px; margin-bottom:0px;`">Nie udało się
                zapisać okna, spróbuj ponownie :(</p>
        </div>
        <form v-if="!waitingForResponse"
              @submit.prevent="handleOk">
            <div class="form-groups form-label col-6">
                <label>Nazwa okna</label>
                <input v-model="name"
                       data-vv-as="Nazwa okna"
                       class="form-control"/>
            </div>
            <div class="form-group form-label col-6">
                <label>Opis</label>
                <textarea v-model="description"
                          placeholder="Dodatkowy opis"
                          class="form-control">
                </textarea>
            </div>
            <div class="form-group form-check col-6">
                <b-form-checkbox
                        id="terraristics-window-is-public"
                        v-model="isPublic"
                        value="true"
                        unchecked-value="false">
                    Czy jest publiczne?
                </b-form-checkbox>
            </div>
        </form>
        <template v-else>
            <loading-page/>
        </template>

        <template v-slot:modal-footer="{ ok, cancel }">
            <b-button size="sm" variant="success" @click="handleOk">
                Zapisz
            </b-button>
            <b-button size="sm" variant="danger" @click="handleCancel">
                Anuluj
            </b-button>
        </template>
    </b-modal>
</template>

<script lang="ts">
    import {Component, Emit, Vue} from "vue-property-decorator";
    import {terraristicsWindowApiImpl} from "@/api/terraristics-window-api";

    @Component
    export default class UserTerraristicWindowAddModal extends Vue {
        failedOnCreate: Boolean = false;
        waitingForResponse: Boolean = false;
        name: string = "";
        description: string = "";
        isPublic: boolean = false;

        async handleOk(evt: any) {
            try {
                evt.preventDefault();
                this.saveNewWindow();
            } catch (e) {
                console.error(e);
            }
        };

        handleCancel() {
            this.resetModalData();
            this.hideModal();
        }

        resetModalData() {
            this.name = '';
            this.description = '';
            this.failedOnCreate = false;
            this.waitingForResponse = false;
            this.isPublic = false;
        };

        hideModal() {
            // @ts-ignore
            this.$refs.addUserTerraristicWindowModal.hide();
        }

        saveNewWindow() {
            this.waitingForResponse = true;
            let request = {
                Name: this.name,
                Description: this.description,
                IsPublic: this.isPublic
            };

            terraristicsWindowApiImpl.create(request)
                .then(() => {
                    this.resetModalData();
                    this.hideModal();
                    this.successfullyAdded();
                })
                .catch(err => {
                    console.error(err.message);
                })
                .finally(() => {
                    this.waitingForResponse = false;
                    this.failedOnCreate = true;
                })
        };

        @Emit()
        successfullyAdded() {
            return true;
        }
    }
</script>
