<template>
    <div class="page">
        <ValidationObserver ref="observer" v-slot="{ invalid }">
            <b-form @submit.prevent="onSubmit" novalidate>
                <b-form-group label="Description">
                    <ValidationProvider name="description" rules="required" v-slot="{ errors }">
                        <b-form-input
                                :state="errors.length == 0"
                                v-model="form.description"
                                type="text"
                                required
                                placeholder="Description"
                                name="description"
                        ></b-form-input>
                        <b-form-invalid-feedback :state="errors.length == 0">Description is required</b-form-invalid-feedback>
                    </ValidationProvider>
                </b-form-group>
                <b-form-group label="Amount">
                    <ValidationProvider name="amount" rules="required|min_value:0" v-slot="{ errors }">
                        <b-form-input
                                :state="errors.length == 0"
                                v-model="form.amount"
                                type="text"
                                required
                                placeholder="Amount"
                        ></b-form-input>
                        <b-form-invalid-feedback :state="errors.length == 0">{{errors.join('. ')}}</b-form-invalid-feedback>
                    </ValidationProvider>
                </b-form-group>
                <b-form-group label="Date">
                    <ValidationProvider name="amount" rules="date" v-slot="{ errors }">
                        <b-form-input
                                :state="errors.length == 0"
                                v-model="form.date"
                                type="text"
                                required
                                placeholder="Date (YYYY/MM/DD)"
                                name="date"
                        ></b-form-input>
                        <b-form-invalid-feedback :state="errors.length == 0">{{errors[0]}}</b-form-invalid-feedback>
                    </ValidationProvider>
                </b-form-group>
                <b-button type="submit">Add</b-button>
            </b-form>
        </ValidationObserver>    <b-table-simple responsive>
        <b-thead>
            <b-tr>
                <b-th sticky-column>Description</b-th>
                <b-th>Amount</b-th>
                <b-th>Date</b-th>
                <b-th>Delete</b-th>
            </b-tr>
        </b-thead>
        <b-tbody>
            <b-tr v-for="e in expenses" :key="e.id">
                <b-th sticky-column>{{e.description}}</b-th>
                <b-td>${{e.amount}}</b-td>
                <b-td>{{e.date | formatDate}}</b-td>
                <b-td>
                    <b-button @click="deleteSingleExpense(e.id)">Delete</b-button>
                </b-td>
            </b-tr>
        </b-tbody>
    </b-table-simple>
    </div>
</template><script>
    import "bootstrap/dist/css/bootstrap.css";
    import "bootstrap-vue/dist/bootstrap-vue.css";
    import { requestsMixin } from "../mixins/requestsMixin";export default {
        name: "home",
        mixins: [requestsMixin],
        data() {
            return {
                form: {}
            };
        },
        beforeMount() {
            this.getAllExpenses();
        },
        computed: {
            expenses() {
                return this.$store.state.expenses;
            }
        },
        methods: {
            async onSubmit() {
                const isValid = await this.$refs.observer.validate();
                if (!isValid) {
                    return;
                }
                await this.addExpense(this.form);
                await this.getAllExpenses();
            },  async getAllExpenses() {
                const response = await this.getExpenses();
                this.$store.commit("setExpenses", response.data);
            },  async deleteSingleExpense(id) {
                const response = await this.deleteExpense(id);
                await this.getAllExpenses();
            }
        }
    };
</script>