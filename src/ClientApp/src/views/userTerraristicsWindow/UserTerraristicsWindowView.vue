<template>
    <div class="p-5">
        <b-row v-if="!isLoadingData">
            <b-col>
                <b-row>
                    <b-col cols="6" v-for="(window, index) in terraristicsWindows"
                           :key="`window-block-${window.Id}-${index}`">
                        <window-block
                                :data="window"
                                class="cursor-pointer"
                                @click.native="updateAdditionalInformation(window.Id)"
                                @edit-terraristics-window="openEditWindowModal"/>
                    </b-col>
                </b-row>
            </b-col>
            <b-col cols="1"/>
            <b-col cols="3">
                <div class="card card-green">
                    <div class="card card-header font-weight-bold card-header-background">
                        <span>Zarządzanie oknami</span>
                        <i class="fa-pull-right fas fa-sync 2px cursor-pointer" @click="refreshData"></i>
                    </div>
                    <div class="card-body">
                        <b-button @click="openAddWindowModal" class="btn btn-primary text-white">
                            Dodaj nowe okno
                        </b-button>
                    </div>
                    <div class="card-header font-weight-bold card-header-background">
                        Informacje dodatkowe
                    </div>
                    <div class="card-body">
                        <table class="table text-white">
                            <tbody>
                            <tr>
                                <th>Nazwa:</th>
                                <th>{{selectedWindow.Name}}</th>
                            </tr>
                            <tr>
                                <th>Klucz Api:</th>
                                <th>{{selectedWindow.ApiKey}}</th>
                            </tr>
                            <tr>
                                <th>Data stworzenia:</th>
                                <th>{{selectedWindow.CreationDate | moment('YYYY-MM-DD')}}</th>
                            </tr>
                            <tr>
                                <th>Data modyfikacji:</th>
                                <th>{{selectedWindow.ModificationDate | moment('YYYY-MM-DD')}}</th>
                            </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </b-col>
        </b-row>
        <loading-page v-else :size="8"/>

        <user-terraristic-window-add-modal/>
        <user-terraristic-window-edit-modal :selected-window="selectedWindowToEdit"/>
    </div>
</template>

<script lang="ts">
    import {Component, Vue} from "vue-property-decorator";
    import WindowBlock from "@/components/common/WindowBlock.vue";
    import UserTerraristicWindowAddModal from "./components/modals/UserTerraristicWindowAddModal.vue";
    import UserTerraristicWindowEditModal from "./components/modals/UserTerraristicWindowEditModal.vue";
    import {TerraristicsModule} from "@/store/modules/terraristics-module";


    @Component({
        components: {
            UserTerraristicWindowEditModal,
            WindowBlock,
            UserTerraristicWindowAddModal,
        }
    })

    export default class UserTerraristicsWindowView extends Vue {
        selectedWindow!: TerraristicsWindowFormData;
        selectedWindowToEdit: any = {};
        isLoadingData: boolean = true;

        get terraristicsWindows() {
            return TerraristicsModule.TerraristicsWindows;
        }

        created() {
            this.getTerraristicsWindows();
        }

        refreshData() {
            this.isLoadingData = true;
            this.getTerraristicsWindows();
        }

        getTerraristicsWindows() {
            TerraristicsModule.GET_LIST()
                .then(response => {
                    if (response) {
                        const firstTerraristicsWindowId = this.terraristicsWindows[0].Id;
                        this.isLoadingData = false;
                        this.updateAdditionalInformation(firstTerraristicsWindowId);
                    }
                })
        }

        updateAdditionalInformation(windowId: number) {
            if (!this.terraristicsWindows) {
                return;
            }

            let terraristicsWindow = this.terraristicsWindows.find(terraristicsWindow => {
                return terraristicsWindow.Id === windowId;
            });

            if (terraristicsWindow) {
                this.selectedWindow = terraristicsWindow;
            }
        }

        openAddWindowModal() {
            this.$bvModal.show("user-window-add-modal");
        }

        openEditWindowModal(windowId: number) {
            let terraristicsWindow = this.terraristicsWindows.find(terraristicsWindow => {
                return terraristicsWindow.Id === windowId;
            });
            this.selectedWindowToEdit = <TerraristicsWindowFormData>{
                id: terraristicsWindow.Id,
                name: terraristicsWindow.Name,
                description: terraristicsWindow.Description
            };

            this.$bvModal.show("user-window-edit-modal");
        }
    }
</script>
<style scoped>
    .btn-primary {
        color: #fff;
        background-color: #a4651c;
        border-color: #ffac4c;
    }

    .btn-primary:hover {
        background-color: #e3be20;
        border-color: #d5ab43;
    }

    .btn-primary:focus {
        background-color: #e3be20;
        border-color: #d5ab43;
        box-shadow: 0 0 0 0.2rem #d5ab43;
    }

    .btn-primary:active {
        background-color: #e3be20;
        box-shadow: 0 0 0 0.2rem #d5ab43;
        border-color: #d5ab43;
    }
</style>