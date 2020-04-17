<template>
    <b-modal
            id="user-window-add-modal"
            title="Dodanie nowego okna"
            size="md"
            button-size="sm"
            ref="addUserTerraristicWindowModal">
        <div v-show="operationFailed" class="alert alert-danger text-center modal-alert"
             :style="`padding: 0`">
            <p class="text-danger" :style="`font-size: 16px; margin-bottom:0px;`">Nie udało się
                zapisać okna, spróbuj ponownie :(</p>
        </div>

        <validation-observer v-if="!operationInProgress" ref="observer" v-slot="{ invalid }">
            <b-form @submit.prevent="handleOk">

                <b-form-group>
                    <label>Nazwa okna</label>
                    <validation-provider name="name" rules="required|min:3|max:30" v-slot="{ errors }">
                        <b-form-input v-model="name" :state="errors.length == 0"/>
                        <b-form-invalid-feedback :state="errors.length == 0">
                            {{ errors[0] }}
                        </b-form-invalid-feedback>
                    </validation-provider>
                </b-form-group>

                <b-form-group>
                    <label>Opis</label>
                    <validation-provider name="description" rules="max:200" v-slot="{ errors }">
                        <b-form-textarea v-model="description" :state="errors.length == 0"/>
                        <b-form-invalid-feedback :state="errors.length == 0">
                            {{ errors[0] }}
                        </b-form-invalid-feedback>
                    </validation-provider>
                </b-form-group>

                <b-form-group>
                    <b-form-checkbox
                            id="terraristics-window-is-public"
                            v-model="isPublic"
                            value="true"
                            unchecked-value="false">
                        Czy jest publiczne?
                    </b-form-checkbox>
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
            <b-button size="sm" variant="danger" @click="handleCancel">
                Anuluj
            </b-button>
        </template>
    </b-modal>
</template>

<script lang="ts">
    import {Component, Emit} from "vue-property-decorator";
    import {terraristicsWindowApiImpl} from "@/api/terraristics-window-api";
    import FormModalMixin from "@/mixins/form-modal-mixin";

    @Component
    export default class UserTerraristicWindowAddModal extends FormModalMixin {
        name: string = "";
        description: string = "";
        isPublic: boolean = false;

        resetModalData() {
            this.name = '';
            this.description = '';
            this.operationFailed = false;
            this.operationInProgress = false;
            this.isPublic = false;
        };

        hideModal() {
            // @ts-ignore
            this.$refs.addUserTerraristicWindowModal.hide();
        }

        saveNewWindow() {
            this.startOperation();
            let request = {
                Name: this.name,
                Description: this.description,
                IsPublic: this.isPublic
            };

            terraristicsWindowApiImpl.create(request)
                .then(() => {
                    this.operationSuccess();
                    this.resetModalData();
                    this.hideModal();
                    this.successfullyAdded();
                })
                .catch(err => {
                    this.operationFail(err.message);
                });
        };

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

        @Emit()
        successfullyAdded() {
            return true;
        }
    }
</script>
