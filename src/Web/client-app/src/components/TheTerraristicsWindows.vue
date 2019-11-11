<template>
    <div class="p-3">
        <div v-if="isDataLoaded" class="row">
            <div class="col-md-7 row">
                <window-block @edit-window-block="editWindowBlock"/>
            </div>
            <div class="offset-1 col-md-3">
                <terraristics-window-add-block/>
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

        <!--        <user-window-edit-modal/>-->
        <terraristics-window-add-modal/>
    </div>
</template>

<script>
    import WindowBlock from "./common/WindowBlock";
    import LoadingPage from "./common/LoadingPage";
    import TerraristicsWindowAddBlock from "./terraristicsWindow/TerraristicsWindowAddBlock";
    import TerraristicsWindowAddModal from "./terraristicsWindow/modal/TerraristicsWindowAddModal";

    import {GetUserWindowData} from "../utils/object-generator";
    import {mapGetters} from "vuex";
    import types from "../store/types";

    export default {
        components: {
            LoadingPage,
            WindowBlock,
            TerraristicsWindowAddBlock,
            TerraristicsWindowAddModal,
        },
        data() {
            return GetUserWindowData();
        },
        created() {
            //TODO dodać oczekiwanie na odpowiedź z promise
            this.$store.dispatch(types.actions.DICT_GET_ALL_SENSOR_KINDS);
        },
        computed: {
            ...mapGetters({
                inputSensors: types.getters.DICT_GET_INPUT_SENSORS,
                outputSensors: types.getters.DICT_GET_OUTPUT_SENSORS
            }),
            isDataLoaded() {
                return this.loading;
            }
        },
        methods: {
            editWindowBlock(value) {
                //TODO sklonowac item o danym indexu z listy okien, wyslac do modala i tam edytować
            }
        }
    };
</script>

<style scoped></style>
