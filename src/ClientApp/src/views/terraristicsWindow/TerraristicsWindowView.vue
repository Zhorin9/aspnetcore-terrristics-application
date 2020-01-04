<template>
    <div>
        <b-container fluid class="align-items-center">
            <b-row>
                <sensor-block v-for="(sensorBlock, index) in sensorBlocks"
                              :key="`sensorBlock-${index}`"/>
                <b-col cols="6">
                    <plus-component @add-new-element="openAddSensorBlockModal"/>
                </b-col>
            </b-row>
        </b-container>
        
        <terraristics-window-add-sensor-blocks-modal/>
    </div>
</template>

<script lang="ts">
    import {Component, Prop, Vue} from "vue-property-decorator";
    import SensorBlock from "@/components/SensorBlock.vue";
    import PlusComponent from "@/components/common/PlusComponent.vue";
    import {SensorBlockModule} from "@/store/modules/sensor-block-module";
    import TerraristicsWindowAddSensorBlocksModal
        from "@/views/terraristicsWindow/components/modals/TerraristicsWindowAddSensorBlocksModal.vue";


    @Component({
        components: {
            SensorBlock,
            PlusComponent,
            TerraristicsWindowAddSensorBlocksModal
        }
    })
    export default class TerraristicsWindowView extends Vue {
        @Prop() id!: string;

        get sensorBlocks() {
            return SensorBlockModule.SensorBlocks;
        }

        created() {
            SensorBlockModule.GET_LIST(this.id);
        }

        openAddSensorBlockModal() {
            this.$bvModal.show("terraristics-window-add-sensor-blocks-modal");
        }
    }
</script>

<style scoped>
</style>