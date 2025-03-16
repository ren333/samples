Netbox configuration via Docker Compose
==============

# Resources
* [Netbox Site](https://github.com/netbox-community/netbox)
* [Introduction](https://netboxlabs.com/docs/netbox/en/stable/introduction/)
* [Sample environment settings for Docker](https://docs.linuxserver.io/images/docker-netbox/)
* [Docker Compose sample config (for Synology devices)](https://chochol.io/en/software/netbox-installation-guide-for-synology-on-docker-compose/)
* [Redis MISCONF error for RDB](https://stackoverflow.com/questions/60743175/docker-misconf-redis-is-configured-to-save-rdb-snapshots)
* [Redis base config](https://raw.githubusercontent.com/antirez/redis/4.0/redis.conf)

# Configuration files
* `postgres.env` - PostgreSQL database environment variables.
* `netbox.env` - Netbox environment variables.
    * Take note of `ALLOWED_HOSTS` - this seems to do nothing here.
    * Must change the value in the `configuration.py` file instead.
* `redis.conf` - Redis default configuration.
* `/tmp/netbox/config/configuration.py` - Modify the following:
    * `ALLOWED_HOSTS = ['localhost', '*']` - Add '*'
    * Otherwise, error message is shown "Bad Request 400".
    * Once the change has been done, restart the container `docker restart netbox_server`

# Login
* Browse to the IP address where docker instance is running on port 13031.
* Use username: **admin** and the password set for the environment variable **SUPERUSER_PASSWORD**

# Troubleshooting
* Ensure the following folders exist:
    * /tmp/netbox/redis
    * /tmp/netbox/config
    * /tmp/netbox/postgres
* `docker exec -it netbox_redis id` - Displays: uid: 1000, gid: 1000, groups: 1000.`
