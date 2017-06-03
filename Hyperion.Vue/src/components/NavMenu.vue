<template>
    <div>
        <ul class="nav nav-sidebar">
            <li class="active"><router-link :to="{ name: 'home' }">主页 <span class="sr-only">(current)</span></router-link></li>
            <li><a href="#">Reports</a></li>
            <li><a href="#">Analytics</a></li>
            <li><a href="#">Export</a></li>
        </ul>
        <ul class="nav nav-sidebar">
            <li><a href="">Nav item</a></li>
            <li><router-link :to="{ name: 'user' }">用户管理</router-link></li>
            <li><a href="">One more nav</a></li>
            <li><a href="">Another nav item</a></li>
            <li><a href="">More navigation</a></li>
        </ul>
        <ul class="nav nav-sidebar">
            <li><router-link :to="{ name: 'vendor' }">厂家管理</router-link></li>
            <li><a href="">Nav item again</a></li>
            <li><a href="">One more nav</a></li>
            <li><a href="">Another nav item</a></li>
        </ul>
    </div>
</template>

<script>
export default {
    name: 'navmenu',
    data () {
        return {
        }
    }
}
</script>
