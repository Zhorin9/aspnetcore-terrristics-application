<template>
    <div class="m-3">
        <b-card class="card-green" :title="data.Name" :img-src="iconUrl" img-alt="Image" img-top>
            <b-card-text algin="left">
                {{data.Description}}
                <div>
                    <b-button 
                              class="ml-1"
                              size="sm">
                        Edytuj
                    </b-button>
                    <b-button :to="{name: 'terraristicsData', params:{id: data.Id}}"
                            class="ml-1" 
                            variant="info" 
                            size="sm">
                        Podgląd
                    </b-button>
                </div>
            </b-card-text>
            <template v-slot:footer>
                <small class="text-muted">Data utworzenia: {{data.CreationDate}} </small>
            </template>
        </b-card>
    </div>
</template>

<script lang="ts">
    import {Component, Prop, Vue} from "vue-property-decorator";

    @Component({})

    export default class WindowBlock extends Vue {
        @Prop() data: TerraristicsWindow | undefined;

        windowIndex: number = 2;

        //TODO do webpacka
        get iconUrl() {
            return require('@/assets/homeBackground.jpg')
        }

        editWindowBlock() {
            this.$emit("edit-window", this.windowIndex);
        };

        removeWindowBlock() {
            this.$emit("remove-window", this.windowIndex);
        }
    }
</script>

<style scoped>
    .btn-green {
        color: #fff;
        background-color: #061611;
        border-color: #5b8111;
    }

    .btn-sm {
        padding: 0.25rem 0.5rem;
        font-size: 0.75rem;
        line-height: 1.5;
        border-radius: 0.2rem;
    }

    .card-header-background {
        background: #0a281d !important;
    }

    .cursor-pointer {
        cursor: pointer;
    }

    .btn-remove {
        color: #fff;
        background-color: #642020;
        border-color: #ac0e23;
    }
</style>
