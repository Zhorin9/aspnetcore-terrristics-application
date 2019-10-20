<template>
    <div class="row p-3">
        <div class="col-md-7 row">
            <window-block v-for="" @edit-window-block="editWindowBlock"/>
        </div>
        <div class="col-md-4">
            <add-block/>
            <information-block/>
        </div>
        <edit-window-modal/>
    </div>
</template>

<script>
    import WindowBlock from "./common/WindowBlock";
    import {GetUserWindowData} from "../utils/object-generator";
    import InformationBlock from "./userWindow/InformationBlock";
    import EditWindowModal from "./userWindow/modal/EditWindowModal";
    import AddBlock from "./userWindow/AddBlock";

    export default {
        components: {
            EditWindowModal,
            AddBlock,
            InformationBlock,
            WindowBlock,
        },
        data() {
            return GetUserWindowData();
        },
        methods: {
            editWindowBlock(value) {
                //TODO sklonowac item o danym indexu z listy okien, wyslac do modala i tam edytować
            }
        }
    };
</script>

<style>
    .card-green {
        border: 2px solid #507000 !important;
        border-radius: 3px;
        background: #182217 !important;
        color: white;
        text-align: left;
        padding-left: 0 !important;
        padding-right: 0 !important;
    }
</style>
