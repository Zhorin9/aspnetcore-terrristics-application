<template>
    <div class="card card-green">
        <div class="card card-header font-weight-bold card-header-background">
            Zarządzanie oknami
        </div>
        <div class="card-body">
            <b-button v-b-modal.add-window-modal class="btn btn-primary text-white">
                Dodaj nowe okno
            </b-button>
        </div>
        <add-window-modal/>
    </div>
</template>

<script>
    import AddWindowModal from "./modal/AddWindowModal";

    export default {
        components: {
            AddWindowModal
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
