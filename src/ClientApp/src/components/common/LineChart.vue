<script lang="ts">
    import {Line, mixins} from 'vue-chartjs'
    import {Component, Prop, Vue} from "vue-property-decorator";

    @Component({
        extends: Line,
        mixins: [mixins.reactiveProp]
    })
    export default class LineChart extends Vue {
        @Prop({default: null}) chartData!: object;
        @Prop({default: null}) chartOptions!: object;
        private renderChart!: (chartData: any, options: any) => void;
        private defaultChartOptions: any = {
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                xAxes: [{
                    display: false
                }],
            }
        };
        
        get chartConfiguration(){
            return this.chartOptions ? this.chartOptions : this.defaultChartOptions;
        }
        mounted() {
            this.renderChart(this.chartData, this.chartConfiguration);
        }
    }
</script>