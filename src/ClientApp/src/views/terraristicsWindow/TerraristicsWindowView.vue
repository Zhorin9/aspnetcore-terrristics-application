<template>
    <div>
        <b-container fluid class="align-items-center">
            <b-row>
                <terraristics-window-sensor-block v-for="(sensorBlock, index) in sensorBlocks"
                                                  :key="`sensorBlock-${index}`"
                                                  :sensor-block="sensorBlock"
                                                  @edit-sensor-block="editSensorBlock"/>
                <b-col cols="6">
                    <plus-component @add-new-element="openAddSensorBlockModal"/>
                </b-col>
            </b-row>
        </b-container>

        <terraristics-window-add-sensor-block-modal :window-id="id"
                                                    @created-new-sensor-block="refreshSensorsList"/>
        <terraristics-window-edit-sensor-block-modal :selected-sensor-block="sensorBlockToEdit"
                                                     @updated-sensor-block="refreshSensorsList"/>
    </div>
</template>

<script lang="ts">
    import {SensorBlockModule} from "@/store/modules/sensor-block-module";
    import {Component, Prop, Vue} from "vue-property-decorator";
    import PlusComponent from "@/components/common/PlusComponent.vue";
    import TerraristicsWindowAddSensorBlockModal
        from "@/views/terraristicsWindow/components/modals/TerraristicsWindowAddSensorBlockModal.vue";
    import TerraristicsWindowSensorBlock from "@/views/terraristicsWindow/components/TerraristicsWindowSensorBlock.vue";
    import TerraristicsWindowEditSensorBlockModal
        from "@/views/terraristicsWindow/components/modals/TerraristicsWindowEditSensorBlockModal.vue";
    import _ from "lodash";

    @Component({
        components: {
            TerraristicsWindowEditSensorBlockModal,
            TerraristicsWindowSensorBlock,
            PlusComponent,
            TerraristicsWindowAddSensorBlockModal
        }
    })
    export default class TerraristicsWindowView extends Vue {
        @Prop() id!: string;
        sensorBlockToEdit: SensorBlockModel = <SensorBlockModel>{};

        get sensorBlocks() {
            return SensorBlockModule.SensorBlocks;
        }

        created() {
            SensorBlockModule.GET_LIST(this.id);
        }

        openAddSensorBlockModal() {
            this.$bvModal.show("terraristics-window-add-sensor-blocks-modal");
        }

        refreshSensorsList() {
            SensorBlockModule.GET_LIST(this.id);
        }

        editSensorBlock(sensorBlock: SensorBlockModel) {
            this.sensorBlockToEdit = _.clone(sensorBlock);
            this.$bvModal.show("terraristics-window-edit-sensor-blocks-modal");
        }
    }
</script>