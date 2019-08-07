<template>
    <div>
        Aktualnie nie posiadasz okien
    </div>
</template>

<script>
    import {GetUserWindowData} from "../utils/object-generator";

    export default {
        data(){
          return GetUserWindowData();
        },
    };
</script>

<style>

</style>
