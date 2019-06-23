<template>
  <nav>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css">
    <b-navbar toggleable="lg" type="dark" class="nav-green">
      <b-navbar-brand active class="navbar-brand" to="/"> 
            Moje Terrarium <i class="fas fa-frog"></i> 
      </b-navbar-brand>
      <b-navbar-nav>
        <b-nav-item to="/TerraristicWindow">Okna</b-nav-item>
      </b-navbar-nav>
      <div v-show="loggingIn">
        <b-navbar-nav>
          <b-nav-item-dropdown>
              <template slot="button-content">User</template>
              <b-dropdown-item :to="{name: 'LoginPage'}">
                Zaloguj
              </b-dropdown-item >
              <b-dropdown-item >Wyloguj</b-dropdown-item >
          </b-nav-item-dropdown>
        </b-navbar-nav>
      </div>
      <div v-show="!loggingIn" class="ml-auto">
        <b-navbar-nav>
          <b-nav-item right to="/LoginPage">Zaloguj</b-nav-item>
          <b-nav-item right to="/RegisterPage">Zarejestruj się</b-nav-item>
        </b-navbar-nav>
      </div>
    </b-navbar>
  </nav>
</template>

<script>
export default {
  name: 'Navigation',
  data(){
    return{
      test: this.$store.state.authentication,
    }
  },
  computed: { 
    loggingIn () {
      return this.$store.state.authentication.status.loggingIn;
    },
    getUserEmail(){
      return this.$store.state.authentication;
    }
  }
};
</script>

<style scoped>
.nav-green {
  background-image: linear-gradient(30deg,#040E0D,#1E6036);
}
.b-nav-dropdown{
  background-color: #1a5330;
  border-radius: 50%;
}
.dropdown-item {
    color: #fff;
    text-decoration: none;
}
.dropdown-item:hover, .dropdown-item:focus{
    background-color: #164629 !important;
}
.dropdown-item.active{
    color: #fff;
    background-color: #0e2d1d !important;
    opacity: 0.5;
}
</style>