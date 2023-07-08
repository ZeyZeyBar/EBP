# EBP

Elekrtonik ve Mekanik üzerine çalışan bir firmanın envanter kontrol sistemidir. Üç farklı kullanıcı rolü bulunmaktadır. Personel, Şef ve Admin. 
Personel : Sadece kendi profilini ve departmanına ait envanter listesini görüntüleme yetkisine sahiptir.
Şef: Kendi kullanıcı profilini görüntülerken; sadece kendi departmanına ait envanter listesini görme, güncelleme, ekleme ve silme yetkisine sahiptir.
Admin : Kendi kullanıcı profilini görme ve tüm personelleri ekleme, güncelleme, görme ve silme; Uygulamaya login olacak kullanıcı listesini ekleme, güncelleme, görme ve silme; malzeme tipi listesini ekleme, güncelleme, görme ve silme yetkiyle son olarak şirketteki departmanları ekleme,güncelleme, görme ve silme sahiptir.

Aşağıda bir tane admin ve üç farklı departmana ait Şef ve Personel yetkilerinde kullanıcı bilgileri yer almaktadır.

Kullanıcı Adı               Şifre
admin                       admin
mekanikPersonel             mekanikPersonel
mekanikSef                  mekanikSef
elektrikSef                 elektrikSef
elektrikPersonel            elektrikPersonel
bilgiSistemleriSef           bilgiSistemleriSef
bilgiSistemleriPersonel      bilgiSistemleriPersonel

NOT: SQL Script dosyası da proje dosyaları içinde yer almaktadır. Code kısmında ebp_dbsrcipt.sql adında görebilirsiniz. Veri ve şemalar içeren script de Code içindedir.
