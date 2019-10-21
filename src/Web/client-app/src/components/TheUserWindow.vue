<template>
    <div class="p-3">
        <div class="row">
            <div class="col-md-7 row">
                <window-block @edit-window-block="editWindowBlock"/>
            </div>
            <div class="offset-1 col-md-3">
                <add-block/>
                <information-block/>
            </div>
            <!--        <edit-window-modal/>-->
        </div>
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

</style>
