<template>
    <div class="card card-green m-3 col-md-5">
        <div class="card-header card-header-background">
            <span class="cursor-pointer">{{mockedWindow.Name}}</span>
            <button @click="editWindowBlock" class="float-right btn btn-green btn-sm">Edytuj</button>
            <button @click="editWindowBlock" class="float-right btn btn-remove btn-sm">Usuń</button>
        </div>
        <img src="../../assets/homeBackground.jpg" height="150"/>
        <div class="card-body">
            <p class="card-text text-center">Zwykły test</p>
        </div>
    </div>
</template>

<script lang="ts">
    import {Component, Vue} from "vue-property-decorator";

    @Component({})

    export default class WindowBlock extends Vue {
        //TODO Remove mocked data
        mockedWindow: object = {
            Name: String("Moje terarium"),
            DateCreated: String("2019-09-01"),
            Description: String("Terrarium zostało stworzone na potrzeby bla bla"),
            Checked: Boolean(false),
        };
        windowIndex: number = 2;


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
