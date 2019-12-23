<template>
    <table class="table table-sm text-light">
        <thead class="thead-dark">
        <tr>
            <th>Czujnik</th>
            <th>Ilość</th>
            <th style="width: 120px">Akcja</th>
        </tr>
        </thead>
        <tbody>
        <tr v-for="(sensor, index) in sensors">
            <td :key="`input-sensor-${{index}}`">
                {{sensor.name}}
            </td>
            <td>
                {{sensor.count}}
            </td>
            <td>
                <button class="btn btn-light mt-2 mr-1 btn-xs"
                        @click="increaseCount(sensor)"
                        type="button">
                    Dodaj
                </button>
                <button v-if="showRemoveButton(sensor)"
                        @click="decreaseCount(sensor)"
                        class="btn btn-light mt-2 btn-xs"
                        type="button">
                    Usuń
                </button>
            </td>
        </tr>
        </tbody>
    </table>
</template>

<script lang="ts">
    import {Component, Prop, Vue} from "vue-property-decorator";

    @Component
    export default class UserTerraristicWindowTable extends Vue {
        @Prop({default: Array(0)}) sensors!: Array<any>;

        showRemoveButton(value: any) {
            return value.count > 1;
        };

        increaseCount(value: any) {
            let increasedCount = value.count + 1;
            this.$emit("update-count", {
                id: value.id,
                count: increasedCount
            })
        };

        decreaseCount(value: any) {
            let currentCount = value.count;
            if (currentCount > 1) {
                --currentCount;
            }
            this.$emit("update-count", {
                id: value.id,
                count: currentCount
            })
        };
    }
</script>

<style scoped>
    .btn {
        font-size: 9px;
        border-radius: 0px;
    }

    .btn-group-xs > .btn, .btn-xs {
        padding: .3rem .4rem;
        font-size: .9rem;
        line-height: .5;
        border-radius: 0px;
    }
</style>
