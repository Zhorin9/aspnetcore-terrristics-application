<template>
    <div class="p-5">
        <b-row v-if="!isDataLoading">
            <b-col>
                <b-row>
                    <b-col cols="6" v-for="(window, index) in terraristicsWindows"
                           :key="`window-block-${window.Id}-${index}`">
                        <window-block
                                :data="window"
                                class="cursor-pointer"
                                @click.native="updateAdditionalInformation(window.Id)"
                                @edit-terraristics-window="openEditWindowModal"
                                @delete-terraristics-window="openDeleteModal"/>
                    </b-col>
                </b-row>
            </b-col>
            <b-card class="card-green height-fix-content management-block" header-tag="header">
                <template class="card-header-background" v-slot:header>
                    <div class="font-weight-bold">
                        <h3>Zarządzanie oknami</h3>
                        <font-awesome-icon v-b-tooltip.hover title="Odśwież okna" :icon="['fa', 'sync']"
                                           class="fa-pull-right cursor-pointer"
                                           @click="refreshData"/>
                    </div>
                </template>
                <b-button @click="openAddWindowModal" class="btn btn-primary text-white">
                    Dodaj nowe okno
                </b-button>

                <h4 class="mt-4">Dodatkowe informacje</h4>
                <b-table caption-top responsive stacked
                         :items="[selectedWindowToDisplay]"
                         :fields="fieldDefinitions"
                         class="text-black-50">
                </b-table>
            </b-card>
        </b-row>
        <loading-page v-else :size="8"/>

        <user-terraristic-window-add-modal @successfully-added="refreshData"/>
        <user-terraristic-window-edit-modal :selected-window="selectedWindowToEdit" @updated-correct="handleUpdate"/>
        <simple-dialog :id="'user-window-delete-modal'" @result="handleDelete"/>
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
        selectedWindowToDisplay: TerraristicsWindowModel = <TerraristicsWindowModel>{};
        selectedWindowToEdit: TerraristicsWindowFormData = <TerraristicsWindowFormData>{};
        selectedWindowIdToDelete: number = 0;
        isDataLoading: boolean = true;

        get terraristicsWindows() {
            return TerraristicsModule.TerraristicsWindows;
        }

        created() {
            this.getTerraristicsWindows();
        }

        refreshData() {
            this.isDataLoading = true;
            this.getTerraristicsWindows();
        }

        getTerraristicsWindows() {
            TerraristicsModule.GET_LIST()
                .then(response => {
                    if (response) {
                        const firstTerraristicsWindowId = this.terraristicsWindows[0].Id;
                        this.updateAdditionalInformation(firstTerraristicsWindowId);
                    }
                })
                .catch(err => {
                    console.error(err);
                })
                .finally(() => {
                    this.isDataLoading = false;
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
                this.selectedWindowToDisplay = terraristicsWindow;
            }
        }

        handleDelete(value: boolean) {
            if (value) {
                TerraristicsModule.DELETE_WINDOW(this.selectedWindowIdToDelete)
                    .then(() => {
                        this.$bvModal.hide('user-window-delete-modal');
                        this.refreshData();
                    })
                    .catch(err => {
                        console.error(err);
                    })
            }
        }

        handleUpdate(data: TerraristicsWindowFormData) {
            this.selectedWindowToEdit = <TerraristicsWindowFormData>{};
            let terraristicsWindow = this.terraristicsWindows.find(terraristicsWindow => {
                return terraristicsWindow.Id === data.id;
            });
            terraristicsWindow.Name = data.name;
            terraristicsWindow.Description = data.description;
            terraristicsWindow.IsPublic = data.isPublic;
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
                description: terraristicsWindow.Description,
                isPublic: terraristicsWindow.IsPublic
            };

            this.$bvModal.show("user-window-edit-modal");
        }

        openDeleteModal(windowId: number) {
            this.selectedWindowIdToDelete = windowId;
            this.$bvModal.show("user-window-delete-modal");
        }

        fieldDefinitions: any = [
            {key: 'Name', label: 'Nazwa'},
            {key: 'ApiKey', label: 'Klucz Api'},
            {
                key: 'CreationDate',
                label: 'Data utworzenia',
                formatter: (value: any, key: any, item: any) => {
                    //@ts-ignore    
                    return this.$moment(value).format('YYYY-MM-DD')
                }
            },
            {
                key: 'ModificationDate',
                label: 'Data modyfikacji',
                formatter: (value: any, key: any, item: any) => {
                    //@ts-ignore    
                    return this.$moment(value).format('YYYY-MM-DD')
                }
            },
            {
                key: 'IsPublic',
                label: 'Czy jest publiczne',
                formatter: (value: any, key: any, item: any) => {
                    return value ? "Tak" : "Nie";
                }
            },
        ];
    }
</script>
<style scoped>
    .btn-primary {
        color: #fff;
        background-color: #85b262;
        border-color: #85b262;
    }

    .btn-primary:hover,
    .btn-primary:active,
    .btn-primary:visited,
    .btn-primary:focus {
        background-color: #bad669;
        box-shadow: 0 0 0 0.2rem #adc75a;
        border-color: #adc75a;
    }

    .management-block {
        top: 20px;
        position: -webkit-sticky;
        position: sticky;
    }
</style>