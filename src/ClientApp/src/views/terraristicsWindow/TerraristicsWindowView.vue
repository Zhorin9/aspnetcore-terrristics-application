<template>
    <div>
        {{id}}
    </div>
</template>

<script lang="ts">
    import {Component, Prop, Vue} from "vue-property-decorator";
    import {terraristicsWindowApiImpl} from "@/api/terraristics-window-api";


    @Component({})
    export default class TerraristicsWindowView extends Vue {
        @Prop() id!: string;

        created() {
            // this.getTerraristicsWindow(this.id);
        }
        
        // getTerraristicsWindow(id: string) {
            // terraristicsWindowApiImpl.getTerraristicsWindows(id)
            //     .then(response => {
            //         console.log(response);
            //     })
            //     .catch(err => {
            //         console.error(err);
            //     })
        // }
    }
</script>

<style scoped>
</style>