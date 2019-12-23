<template>
    <b-col cols="6" class="p-5 mt-3">
        <b-card class="card-green">
            TEST
        </b-card>
    </b-col>
</template>

<script lang="ts">
    import {Component, Prop, Vue} from "vue-property-decorator";
    import PlusComponent from "@/components/common/PlusComponent.vue";

    @Component({
        components: {PlusComponent}
    })

    export default class SensorBlock extends Vue {
        @Prop({default: {}}) sensorBlock: SensorBlockModel | undefined;
    }
</script>

<style scoped>
</style>