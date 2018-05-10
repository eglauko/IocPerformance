Ioc Performance
===============

Source code of my performance comparison of the most popular .NET IoC containers:  
[www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison](http://www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison)

Author: Daniel Palme  
Blog: [www.palmmedia.de](http://www.palmmedia.de)  
Twitter: [@danielpalme](http://twitter.com/danielpalme)  

Results
-------
### Explantions
**First value**: Time of single-threaded execution in [ms]  
**Second value**: Time of multi-threaded execution in [ms]  
### Basic Features
|**Container**|**Singleton**|**Transient**|**Combined**|**Complex**|
|:------------|------------:|------------:|-----------:|----------:|
|**No**|57<br/>121|65<br/>137|80<br/>142|87<br/>115|
|**[Valles 1.0-preview2](https://happycenter.visualstudio.com/Vaalles.Inject)**|**98**<br/>**181**|**128**<br/>**176**|**223**<br/>**200**|**520**<br/>**432**|
### Advanced Features
|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Asp Net Core**|**Interception With Proxy**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|---------------:|--------------------------:|
|**No**|112<br/>168|74<br/>110|176<br/>180|71<br/>146|614<br/>496|<br/>|67<br/>138|
|**[Valles 1.0-preview2](https://happycenter.visualstudio.com/Vaalles.Inject)**|<br/>|**188**<br/>**269**|**1445**<br/>**900**|<br/>|<br/>|**2188**<br/>**1445**|<br/>|
### Prepare
|**Container**|**Prepare And Register**|**Prepare And Register And Simple Resolve**|
|:------------|-----------------------:|------------------------------------------:|
|**No**|2<br/>|3<br/>|
|**[Valles 1.0-preview2](https://happycenter.visualstudio.com/Vaalles.Inject)**|**65**<br/>|**693**<br/>|
### Charts
![Basic features](http://www.palmmedia.de/content/blogimages/5225c515-2f25-498f-84fe-6c6e931d2042.png)
![Advanced features](http://www.palmmedia.de/content/blogimages/e0401485-20c6-462e-b5d4-c9cf854e6bee.png)
![Prepare](http://www.palmmedia.de/content/blogimages/67b056a5-9da8-40b4-9ae6-0c838cdac180.png)
### Machine
The benchmark was executed on the following machine:  
**CPU**: Intel(R) Core(TM) i5-7200U CPU @ 2.50GHz  
**Memory**: 7,88GB
