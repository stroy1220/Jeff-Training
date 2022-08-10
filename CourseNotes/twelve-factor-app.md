# Twelve Factor App

"App" - "A Unit of Deployment"
    - A single repository.


# I: Codebase
One code base, many deploys.
The repository hass the information needed to create the deployments.

## II: Dependencies

> Explicitly declare and isolate dependencies.

### III: Config
> Store config in the environment. 

stuff that changes because the environment changes.


### IV: Backing Services

> Treat backing services as attached resources.

### V: Build, Run, Release

> Strictly separate build and run states.

Big point here is don't change code in environments. The built code is the built code. 

In point 3: The stuff that does change per environment goes into config. And that isn't "ours" as developers, that belongs in the environment itself.

### VI: Processes

> Execute the apps as one or more stateless processes.

Stateless here means they hold on to no data between requests. It is is garbage collected, destroyed, etc.

### VII: Port Binding

> Export Services via Port Binding

"Kestral" -


### VIII: Concurrency

> Scale out via the process model

We scale horizontally as opposed to vertically.

### IX: Disposibility

> Maximize robustness with fast startup and graceful shutdonw

You running applications with be shut down and replaced frequently. Don't get emotionally attached to them.

They are "ephemeral"

### X: Dev/Prod Parity

> Keep development (every environment) as close to the same as possible.

### XI: Logs

> Treat logs as event streams

### Admin Processes

> Run admin/management processes tasks as on-off processes

Not a huge deal for you as a developer, but just know that there are things that you are not in control of in your cluster.

For example, you might not EVER deploy a database to the cluster. 
