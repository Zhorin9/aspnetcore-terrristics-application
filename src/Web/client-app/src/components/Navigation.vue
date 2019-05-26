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
      <b-navbar-nav class="ml-auto">
        <b-nav-item-dropdown right>
            <template slot="button-content">User</template>
            <b-dropdown-item >Zaloguj</b-dropdown-item >
            <b-dropdown-item >Wyloguj</b-dropdown-item >
        </b-nav-item-dropdown>
      </b-navbar-nav>
    </b-navbar>
  </nav>
</template>

<script>
export default {
  name: 'Navigation',
};
</script>

<style scoped>
.nav-green {
  background-image: linear-gradient(30deg,#040E0D,#1E6036);
}
.dropdown-item:hover, .dropdown-item {
    color: #fff;
    text-decoration: none;
}
.dropdown-item:hover, .dropdown-item:hover {
    color: #fff;
    background-color: #697b38;
}
.dropdown-item:hover, .dropdown-item:focus {
    color: #fff;
    background-color: #697b38;
}
</style>