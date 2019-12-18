<template>
    <b-row>
        <b-col>
            <b-card class="card-green">
                TEST
            </b-card>
        </b-col>        <b-col>
            <b-card class="card-green">
                TEST
            </b-card>
        </b-col>
    </b-row>
</template>

<script lang="ts">
    import {Component, Prop, Vue} from "vue-property-decorator";

    @Component({})

    export default class SensorBlock extends Vue {
        @Prop({default: Array<SensorBlockModel>(0)}) sensorBlocks: Array<SensorBlockModel> | undefined;
    }
</script>

<style scoped>
</style>