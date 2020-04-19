<template>
    <b-modal
            id="user-window-edit-modal"
            title="Edycja okna"
            size="lg"
            button-size="sm"
            ref="editUserTerraristicWindowModal">
        <div v-show="operationFailed" class="alert alert-danger text-center modal-alert"
             :style="`padding: 0`">
            <p class="text-danger" :style="`font-size: 16px; margin-bottom:0px;`">Nie udało się
                zapisać okna, spróbuj ponownie :(</p>
        </div>
        <form v-if="!operationInProgress"
              @submit.prevent="handleOk">
            
            <b-form-group class="col-6">
                <label>Nazwa okna</label>
                <validation-provider name="name" rules="required|min:3|max:30" v-slot="{ errors }">
                    <b-form-input v-model="selectedWindow.name" :state="errors.length == 0"/>
                    <b-form-invalid-feedback :state="errors.length == 0">
                        {{ errors[0] }}
                    </b-form-invalid-feedback>
                </validation-provider>
            </b-form-group>
            
            <b-form-group class="col-6">
                <label>Opis</label>
                <validation-provider name="description" rules="max:200" v-slot="{ errors }">
                    <b-form-textarea v-model="selectedWindow.description" :state="errors.length == 0"/>
                    <b-form-invalid-feedback :state="errors.length == 0">
                        {{ errors[0] }}
                    </b-form-invalid-feedback>
                </validation-provider>
            </b-form-group>
            
            <b-form-group class="col-6">
                <b-form-checkbox
                        id="terraristics-window-is-public"
                        v-model="selectedWindow.isPublic"
                        unchecked-value="false">
                    Czy jest publiczne?
                </b-form-checkbox>
            </b-form-group>
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
    import {Component, Emit, Prop} from "vue-property-decorator";
    import {TerraristicsModule} from "@/store/modules/terraristics-module";
    import BackendOperationMixin from "@/mixins/backend-operation-mixin";

    @Component
    export default class UserTerraristicWindowEditModal extends BackendOperationMixin {
        @Prop() selectedWindow!: TerraristicsWindowFormData;

        handleOk() {
            this.updateData();
        }

        hideModal() {
            // @ts-ignore
            this.$refs.editUserTerraristicWindowModal.hide();
        }

        updateData() {
            this.startOperation();
            TerraristicsModule.UPDATE_WINDOW(this.selectedWindow)
                .then(() => {
                    this.updatedCorrect();
                    this.operationSuccess();
                    this.hideModal();
                })
                .catch(err => {
                    this.operationFail(err);
                })
        }

        @Emit()
        updatedCorrect() {
            return this.selectedWindow;
        }
    }
</script>