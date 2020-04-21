<template>
    <div class="m-3" v-b-tooltip.hover title="Kliknij aby zaktualizować Zarządzanie oknami">
        <b-card class="text-black-50 text-left">
            <b-card-text algin="left">
                {{data.Description}}

                
                <b-list-group>
                    <b-list-group-item href="#" active class="flex-column align-items-start">
                        <div class="d-flex w-100 ">
                            <h5 class="mb-1">Temperatura:</h5>
                        </div>

                        <p class="mb-1">
                            25 stopni.
                        </p>
                    </b-list-group-item>
                    <b-list-group-item>Dapibus ac facilisis in</b-list-group-item>
                    <b-list-group-item>Morbi leo risus</b-list-group-item>
                    <b-list-group-item>Porta ac consectetur ac</b-list-group-item>
                    <b-list-group-item>Vestibulum at eros</b-list-group-item>
                </b-list-group>

            </b-card-text>
            <template v-slot:header>
                <span class="window-block-span">{{data.Name}}</span>
                
                <div class="row float-right">
                    <b-button size="sm" :to="{name: 'terraristicsData', params:{id: data.Id}}" variant="info">
                        <span>Podgląd </span>
                        <font-awesome-icon :icon="['fa', 'search']">
                        </font-awesome-icon>
                    </b-button>
                    <b-button size="sm" @click="editTerraristicsWindow">
                        <span>Edytuj </span>
                        <font-awesome-icon :icon="['fa', 'edit']"/>
                    </b-button>
                    <b-button variant="danger" size="sm" @click="deleteTerraristicsWindow">
                        <span>Usuń </span>
                        <font-awesome-icon :icon="['fa', 'trash']"/>
                    </b-button>
                </div>
                
            </template>
            <template v-slot:footer>
                <small class="text-muted">Data utworzenia: {{data.CreationDate | moment('YYYY-MM-DD')}} </small>
            </template>
        </b-card>
    </div>
</template>

<script lang="ts">
    import {Component, Emit, Prop, Vue} from "vue-property-decorator";

    @Component
    export default class WindowBlock extends Vue {
        @Prop() data: TerraristicsWindowModel | undefined;

        //TODO do webpacka
        get iconUrl() {
            return require('@/assets/homeBackground.jpg')
        }

        get terraristicsWindowId() {
            if (this.data) {
                return this.data.Id;
            }
            return null;
        }

        @Emit()
        editTerraristicsWindow() {
            return this.terraristicsWindowId;
        }

        @Emit()
        deleteTerraristicsWindow() {
            return this.terraristicsWindowId;
        }
    }
</script>

<style scoped>
    .window-block-span {
        font-size: 2rem;
    }
    
    .btn-sm {
        padding: 0.25rem 0.5rem;
        font-size: 0.6rem;
        line-height: 1.5;
        border-radius: 0.2rem;
        margin-left: 5px;
    }

    .btn-info,
    .btn-info:hover,
    .btn-info:active,
    .btn-info:visited,
    .btn-info:focus {
        background-color: #85b262;
        border-color: #85b262;
    }  
    .btn-secondary,
    .btn-secondary:hover,
    .btn-secondary:active,
    .btn-secondary:visited,
    .btn-secondary:focus {
        background-color: #3b8ca8;
        border-color: #3b8ca8;
    }

    .list-group-item {
        z-index: 2;
        color: #fff;
        background-color: #85b262;
        border-color: #f9f871;
    }
</style>
