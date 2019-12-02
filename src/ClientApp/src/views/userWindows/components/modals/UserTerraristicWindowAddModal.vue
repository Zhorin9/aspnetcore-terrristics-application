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
                       name="user-window-add-modal-name"
                       class="form-control"/>
            </div>
            <div class="form-group form-label col-6">
                <label>Opis</label>
                <textarea v-model="description"
                          placeholder="Dodatkowy opis"
                          class="form-control">
                </textarea>
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

<script lang="ts">
    import {Component, Vue} from "vue-property-decorator";
    import {terraristicsWindowApiImpl} from "@/api/terraristics-window-api";
    import LoadingPage from "@/components/common/LoadingPage.vue";
    import UserTerraristicWindowTable from "@/views/userWindows/components/modals/UserTerraristicWindowTable.vue";

    @Component({
        components: {
            LoadingPage,
            UserTerraristicWindowTable
        }
    })
    export default class UserTerraristicWindowAddModal extends Vue {
        failedOnCreate: Boolean = false;
        waitingForResponse: Boolean = false;
        name: string = "";
        description: string = "";

        async handleOk(evt: any) {
            try {
                evt.preventDefault();
                const result = await this.isValid();

                if (!result) {
                    return;
                }
                this.saveNewWindow();
            } catch (e) {
                console.error(e);
            }
        };

        resetModalDataAndGoToCreatedWindow(id: number) {
            // @ts-ignore
            this.$refs.addUserTerraristicWindowModal.hide();
            // this.$router.push({
            //     name: 'TerraristicsWindowData',
            //     id: id
            // });
        };

        saveNewWindow() {
            terraristicsWindowApiImpl.addNewWindow(this.name, this.description)
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
        };

        async isValid(): Promise<boolean> {
            return true;
            // return await this.$validator.validateAll();
        };
    }
</script>
