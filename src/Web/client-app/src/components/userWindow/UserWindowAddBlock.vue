<template>
    <div class="card card-green">
        <div class="card card-header font-weight-bold card-header-background">
            Zarządzanie oknami
        </div>
        <div class="card-body">
            <b-button @click="openModal" class="btn btn-primary text-white">
                Dodaj nowe okno
            </b-button>
        </div>
    </div>
</template>

<script>
    export default {
        methods: {
            openModal() {
                this.$bvModal.show("add-window-modal");
            }
        }
    }
</script>

<style scoped>
    .btn-primary {
        color: #fff;
        background-color: #a4651c;
        border-color: #ffac4c;
    }

    .btn-primary:hover {
        background-color: #e3be20;
        border-color: #d5ab43;
    }

    .btn-primary:focus {
        background-color: #e3be20;
        border-color: #d5ab43;
        box-shadow: 0 0 0 0.2rem #d5ab43;
    }

    .btn-primary:active {
        background-color: #e3be20;
        box-shadow: 0 0 0 0.2rem #d5ab43;
        border-color: #d5ab43;
    }
</style>
