<template>
    <div>
        <b-container fluid v-if="true">
            <b-row>
                <b-col cols="8">
                    <b-row>
                        <b-col cols="6">
                            <window-block v-for="(window, index) in terraristicsWindows"
                                          :key="`window-block-${window.Id}-${index}`"
                                          :data="window"
                                          class="cursor-pointer"
                                          @click.native="updateAdditionalInformation(window.Id)"/>
                        </b-col>
                    </b-row>
                </b-col>
                <b-col cols="1"/>
                <b-col cols="3">
                    <div class="card card-green">
                        <div class="card card-header font-weight-bold card-header-background">
                            Zarządzanie oknami
                        </div>
                        <div class="card-body">
                            <b-button @click="openModal" class="btn btn-primary text-white">
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
                                    <th>{{name}}</th>
                                </tr>
                                <tr>
                                    <th>Klucz Api:</th>
                                    <th>{{apiKey}}</th>
                                </tr>
                                <tr>
                                    <th>Data stworzenia:</th>
                                    <th>{{creationDate  | moment('YYYY-MM-DD')}}</th>
                                </tr>
                                <tr>
                                    <th>Data modyfikacji:</th>
                                    <th>2019-09-01</th>
                                </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </b-col>
            </b-row>
        </b-container>
        <loading-page v-else />

        <user-terraristic-window-add-modal/>
    </div>
</template>

<script lang="ts">
    import {Component, Vue} from "vue-property-decorator";
    import LoadingPage from "@/components/common/LoadingPage.vue";
    import WindowBlock from "@/components/common/WindowBlock.vue";
    import UserTerraristicWindowAddModal from "./components/modals/UserTerraristicWindowAddModal.vue";
    import {TerraristicsModule} from "@/store/modules/terraristics-module";

    @Component({
        components: {
            LoadingPage,
            WindowBlock,
            UserTerraristicWindowAddModal,
        }
    })

    export default class UserTerraristicsWindowView extends Vue {
        name: string = "";
        apiKey: string = "";
        creationDate: Date = new Date();

        get terraristicsWindows() {
            return TerraristicsModule.TerraristicsWindows;
        }

        created() {
            TerraristicsModule.GET_LIST()
                .then(response => {
                    if (response) {
                        const firstTerraristicsWindowId = this.terraristicsWindows[0].Id;
                        this.updateAdditionalInformation(firstTerraristicsWindowId);
                    }
                })
        }

        updateAdditionalInformation(windowId: number) {
            if(!this.terraristicsWindows){
                return;
            }
            
            let terraristicsWindow = this.terraristicsWindows.find(terraristicsWindow => {
                return terraristicsWindow.Id === windowId;
            });

            if (terraristicsWindow) {
                this.name = terraristicsWindow.Name;
                this.apiKey = terraristicsWindow.ApiKey;
                this.creationDate = terraristicsWindow.CreationDate;
            }
        }

        openModal() {
            this.$bvModal.show("user-window-add-modal");
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