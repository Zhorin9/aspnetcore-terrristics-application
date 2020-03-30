<template>
    <b-modal
            id="user-window-edit-modal"
            title="Edycja okna"
            size="lg"
            button-size="sm"
            ref="editUserTerraristicWindowModal">
        <div v-show="failedOnUpdate" class="alert alert-danger text-center modal-alert"
             :style="`padding: 0`">
            <p class="text-danger" :style="`font-size: 16px; margin-bottom:0px;`">Nie udało się
                zapisać okna, spróbuj ponownie :(</p>
        </div>
        <form v-if="!waitingForResponse"
              @submit.prevent="handleOk">
            <div class="form-groups form-label col-6">
                <label>Nazwa okna</label>
                <input v-model="selectedWindow.name"
                       data-vv-as="Nazwa okna"
                       class="form-control"/>
            </div>
            <div class="form-group form-label col-6">
                <label>Opis</label>
                <textarea v-model="selectedWindow.description"
                          placeholder="Dodatkowy opis"
                          class="form-control">
                </textarea>
            </div>
            <div class="form-group form-check col-6">
                <b-form-checkbox
                        id="terraristics-window-is-public"
                        v-model="selectedWindow.isPublic"
                        unchecked-value="false">
                    Czy jest publiczne?
                </b-form-checkbox>
            </div>
        </form>
        <loading-page v-else/>

        <template v-slot:modal-footer="{ ok, cancel }">
            <b-button size="sm" variant="success" @click="handleOk">
                Zapisz
            </b-button>
            <b-button size="sm" variant="danger" @click="hideModal">
                Anuluj
            </b-button>
        </template>
    </b-modal>
</template>

<script lang="ts">
    import {Component, Emit, Prop, Vue} from "vue-property-decorator";
    import {TerraristicsModule} from "@/store/modules/terraristics-module";

    @Component
    export default class UserTerraristicWindowEditModal extends Vue {
        @Prop() selectedWindow!: TerraristicsWindowFormData;
        failedOnUpdate: Boolean = false;
        waitingForResponse: Boolean = false;

        handleOk() {
            this.updateData();
        }

        hideModal() {
            // @ts-ignore
            this.$refs.editUserTerraristicWindowModal.hide();
        }

        updateData() {
            this.failedOnUpdate = false;
            this.waitingForResponse = true;
            TerraristicsModule.UPDATE_WINDOW(this.selectedWindow)
                .then(() => {
                    this.waitingForResponse = false;
                    this.updatedCorrect();
                    this.hideModal();
                })
                .catch(() => {
                    this.failedUpdate();
                })
        }

        failedUpdate() {
            this.failedOnUpdate = true;
            this.waitingForResponse = false;
        }

        @Emit()
        updatedCorrect() {
            return this.selectedWindow;
        }
    }
</script>