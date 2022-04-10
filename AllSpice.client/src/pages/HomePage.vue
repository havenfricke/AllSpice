<template>
  <div class="container-fluid bg-primary">
    <div class="row d-flex justify-content-center">
      <div class="col-12 p-3 d-flex justify-content-center">
        <img
          class="rounded"
          src="https://niemagazine.com/wp-content/uploads/2014/07/fruits-and-vegetables.jpg "
          alt=""
        />
      </div>
    </div>
  </div>
  <div class="container-fluid bg-primary">
    <div class="row d-flex justify-content-center">
      <div class="col-6 p-4 bg-light rounded shadow">
        <span class="row d-flex justify-content-around align-items-center">
          <h5 class="col-3 text-center text-success hoverable">Home</h5>
          <h5 class="col-3 text-center text-success hoverable">My Recipes</h5>
          <h5 class="col-3 text-center text-success hoverable">Favorite</h5>
        </span>
      </div>
    </div>
    <div class="row p-4">
      <div class="col-3 hoverable rounded shadow bg-light">
        <RecipeCard />
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Home'
}
</script>

<style scoped lang="scss">
.hoverable:hover {
  transform: scale(1.03);
  filter: drop-shadow(0px 15px 10px rgba(0, 0, 0, 0.3));
  transition: 0.2s ease-in-out;
  cursor: pointer;
}
.hoverable:active {
  transform: scale(0.98);
  transition: 0.2s ease-in-out;
}
</style>
