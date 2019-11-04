<template>
    <div class="p-3">
        <div v-if="isDataLoaded" class="row">
            <div class="col-md-7 row">
                <window-block @edit-window-block="editWindowBlock"/>
            </div>
            <div class="offset-1 col-md-3">
                <user-window-add-block/>
                <user-window-information-block/>
            </div>
        </div>
        <div v-else>
            <loading-page/>
        </div>

        <!--        <user-window-edit-modal/>-->
        <user-window-add-modal @added-new-window="addedNewWindow"/>
    </div>
</template>

<script>
    import WindowBlock from "./common/WindowBlock";
    import LoadingPage from "./common/LoadingPage";
    import UserWindowAddBlock from "./userWindow/UserWindowAddBlock";
    import UserWindowInformationBlock from "./userWindow/UserWindowInformationBlock";
    import UserWindowAddModal from "./userWindow/modal/UserWindowAddModal";

    import {GetUserWindowData} from "../utils/object-generator";
    import {mapGetters} from "vuex";
    import types from "../store/types";

    export default {
        components: {
            LoadingPage,
            WindowBlock,
            UserWindowAddBlock,
            UserWindowInformationBlock,
            UserWindowAddModal,
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
            },
            addedNewWindow(value){

            }
        }
    };
</script>

<style scoped></style>
