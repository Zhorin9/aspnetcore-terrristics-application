<template>
    <div v-if="hasAnyData">
        <line-chart v-if="showLineChart" :chart-data="chartdata"/>
        <loading-page v-else-if="showLoadingPage" :size="6"/>
        <error-page v-else :size="6"/>
    </div>
    <div v-else-if="!loadingDataProcess">
        Brak danych
    </div>
</template>
<script lang="ts">
    import {Component, Prop, Vue} from "vue-property-decorator";
    import {sensorBlockDataApiImpl} from "@/api/sensor-block-data-api";
    import LineChart from "@/components/common/LineChart.vue";
    import _ from "lodash";

    @Component({
        components: {
            LineChart
        },
    })
    export default class InputSensorBlock extends Vue {
        @Prop({default: null}) sensorBlockId!: number;
        loadingDataProcess: boolean = true;
        showErrorPage: boolean = false;
        chartXData: Array<number> = [];
        chartYData: Array<Date> = [];

        get showLineChart() {
            return !this.loadingDataProcess && !this.showErrorPage;
        }

        get showLoadingPage() {
            return this.loadingDataProcess && !this.showErrorPage;
        }

        get chartdata() {
            return {
                labels: this.chartXData,
                datasets: [
                    {
                        label: 'Dane',
                        backgroundColor: '#3f5741',
                        data: this.chartYData
                    }
                ]
            }
        }

        get hasAnyData() {
            return this.chartXData.length !== 0;
        }
        
        startGetDataProcess(){
            this.loadingDataProcess = true;
            this.chartXData = [];
            this.chartYData = [];
        }

        getData() {
            this.startGetDataProcess();
            sensorBlockDataApiImpl.getList(this.sensorBlockId)
                .then(response => {
                    this.loadingDataProcess = false;
                    _.each(response.data, point => {
                        //@ts-ignore
                        this.chartXData.push(this.$moment(point.CreationDate).format('YYYY-MM-DD'));
                        this.chartYData.push(point.Value);
                    });
                })
                .catch(err => {
                    console.error(err);
                    this.showErrorPage = true;
                });
        }

        mounted() {
            this.getData();
        }
    }
</script>