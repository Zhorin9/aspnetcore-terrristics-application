<template>
    <div v-if="loadingProcess">
        <b-button variant="light" size="sm" @click="refreshState">Odśwież stan</b-button>
        <b-button class="float-right" variant="light ml-1" size="sm" @click="toggleState">{{getTurnOffOnButtonDisplay}}</b-button>
        <div class="text-center">
            <font-awesome-icon :icon="['fa', 'lightbulb']" :class="bulbColor" size="10x"/>
        </div>
    </div>
    <div v-else="loadingDataProcess">
        Brak danych
    </div>
</template>

<script lang="ts">
    import {Component, Prop, Vue} from "vue-property-decorator";
    import {sensorBlockDataApiImpl} from "@/api/sensor-block-data-api";

    @Component
    export default class OutputDigitalSensorBlock extends Vue {
        @Prop({default: null}) sensorBlockId!: number;
        
        loadingProcess: boolean = true;
        state: boolean = false;

        get getTurnOffOnButtonDisplay(){
            return this.state ? 'Wyłącz' : 'Włącz';
        }
        
        get bulbColor(){
            return this.state ? 'bulb-yellow' : '';
        }
        
        created(){
            this.updateCurrentState();
        }
        
        toggleState(){
            let outputDataToUpdate = {
                SensorBlockId: this.sensorBlockId,
                State: this.state
            };
            
            sensorBlockDataApiImpl.createOrUpdateSensorBlockData(outputDataToUpdate)
                .then(response => {
                    console.log(response);
                })
                .catch(err => {
                    console.error();
                });            
            
            this.state = !this.state;
        }

        refreshState(){
            this.updateCurrentState();
        }
        
        updateCurrentState(){
            sensorBlockDataApiImpl.getOutputState(this.sensorBlockId)
                .then(response => {
                    this.state = response.data;
                })
                .catch(err => {
                    console.error(err);
                })
        }
    }
</script>

<style scoped>
    .bulb-yellow{
        color: #e3e35d;
    }
</style>