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

<script lang="ts">
    import {Component, Vue} from "vue-property-decorator";
    import {DictionaryModule} from "@/store/modules/dictionary-module";
    import LoadingPage from "@/components/common/LoadingPage.vue";
    import WindowBlock from "@/components/common/WindowBlock.vue";
    import TerraristicsWindowAddModal from "@/views/terraristics/components/modals/TerraristicsWindowAddModal.vue";
    import TerraristicsWindowAddBlock from "@/views/terraristics/components/TerraristicsWindowAddBlock.vue";

    @Component({
        components: {
            LoadingPage,
            WindowBlock,
            TerraristicsWindowAddBlock,
            TerraristicsWindowAddModal
        }
    })

    export default class TerraristicsView extends Vue{
        created() {
            DictionaryModule.DICT_GET_ALL_SENSOR_KINDS();
        };

        get inputSensor() {
            return DictionaryModule.DICT_GET_INPUT_SENSORS;
        }

        get outputSensors() {
            return DictionaryModule.DICT_SET_OUTPUT_SENSORS;
        }

        editWindowBlock(value: any) {
            //TODO sklonowac item o danym indexu z listy okien, wyslac do modala i tam edytować
        }
    };
</script>