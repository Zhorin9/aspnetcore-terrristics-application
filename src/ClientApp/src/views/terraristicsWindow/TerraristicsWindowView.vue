<template>
    <div>
        <b-container fluid class="align-items-center">
            <b-row>
                <sensor-block v-for="(sensorBlock, index) in sensorBlocks"
                              :key="`sensorBlock-${index}`"/>
                <b-col cols="6">
                    <plus-component @addNewElement=""/>
                </b-col>
            </b-row>
        </b-container>
        
        
    </div>
</template>

<script lang="ts">
    import {Component, Prop, Vue} from "vue-property-decorator";
    import SensorBlock from "@/components/SensorBlock.vue";
    import PlusComponent from "@/components/common/PlusComponent.vue";
    import {SensorBlockModule} from "@/store/modules/sensor-block-module";


    @Component({
        components: {
            SensorBlock,
            PlusComponent
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
    }
</script>

<style scoped>
</style>