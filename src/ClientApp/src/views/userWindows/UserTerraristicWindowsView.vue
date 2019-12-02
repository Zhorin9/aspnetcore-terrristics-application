<template>
    <div class="p-3">
        <div v-if="true" class="row">
            <div class="col-md-7 row">
                <window-block @edit-window-block="editWindowBlock"/>
            </div>
            <div class="offset-1 col-md-3">
                <div class="card card-green">
                    <div class="card card-header font-weight-bold card-header-background">
                        Zarządzanie oknami
                    </div>
                    <div class="card-body">
                        <b-button @click="openModal" class="btn btn-primary text-white">
                            Dodaj nowe okno
                        </b-button>
                    </div>
                </div>
                <div class="card card-green">
                    <div class="card-header font-weight-bold card-header-background">
                        Informacje dodatkowe
                    </div>
                    <div class="card-body">
                        <table class="table text-white">
                            <tbody>
                            <tr>
                                <th>Nazwa:</th>
                                <th>Moje terrarium</th>
                            </tr>
                            <tr>
                                <th>Klucz Api:</th>
                                <th>test</th>
                            </tr>
                            <tr>
                                <th>Data stworzenia:</th>
                                <th>2019-09-01</th>
                            </tr>
                            <tr>
                                <th>Data modyfikacji:</th>
                                <th>2019-09-01</th>
                            </tr>
                            <tr>
                                <th>Liczba terrariów:</th>
                                <th>5</th>
                            </tr>
                            <tr>
                                <th>Liczba czujników:</th>
                                <th>5</th>
                            </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div v-else>
            <loading-page/>
        </div>

        <user-terraristic-window-edit-modal/>
        <user-terraristic-window-add-modal/>
    </div>
</template>

<script lang="ts">
    import {Component, Vue} from "vue-property-decorator";
    import {DictionaryModule} from "@/store/modules/dictionary-module";
    import LoadingPage from "@/components/common/LoadingPage.vue";
    import WindowBlock from "@/components/common/WindowBlock.vue";
    import UserTerraristicWindowAddModal from "@/views/userWindows/components/modals/UserTerraristicWindowAddModal.vue";
    import UserTerraristicWindowEditModal
        from "@/views/userWindows/components/modals/UserTerraristicWindowEditModal.vue";

    @Component({
        components: {
            LoadingPage,
            WindowBlock,
            UserTerraristicWindowAddModal,
            UserTerraristicWindowEditModal
        }
    })

    export default class UserTerraristicWindowsView extends Vue{
        created() {
            DictionaryModule.DICT_GET_ALL_SENSOR_KINDS();
        };

        get inputSensor() {
            return DictionaryModule.DICT_GET_INPUT_SENSORS;
        }

        get outputSensors() {
            return DictionaryModule.DICT_SET_OUTPUT_SENSORS;
        }
        
        openModal() {
            this.$bvModal.show("user-window-add-modal");
        }
        
        editWindowBlock(value: any) {
            //TODO sklonowac item o danym indexu z listy okien, wyslac do modala i tam edytować
        }
    };
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