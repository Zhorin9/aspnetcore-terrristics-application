<template>
    <div>
        <sensor-block/>
    </div>
</template>

<script lang="ts">
    import {Component, Prop, Vue} from "vue-property-decorator";
    import {sensorBlockApiImpl} from "@/api/sensor-block-api";
    import SensorBlock from "@/components/SensorBlock.vue";


    @Component({
        components: {
            SensorBlock
        }
    })
    export default class TerraristicsWindowView extends Vue {
        @Prop() id!: string;
        sensorBlock: Array<any> | undefined;

        created() {
            this.getSensorBlocks(this.id);
        }

        getSensorBlocks(id: string) {
            sensorBlockApiImpl.getSensorBlocks(id)
                .then(response => {
                    // console.log(response);
                })
                .catch(err => {
                    console.error(err);
                })
        }
    }
</script>

<style scoped>
</style>